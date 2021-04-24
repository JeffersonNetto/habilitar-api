using Habilitar_API.Models;
using Habilitar_API.Repositories;
using Habilitar_API.Uow;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Habilitar_API.Controllers
{    
    public class UsuarioController : MainController
    {
        private readonly IUsuarioRepository _repository;
        private readonly IUnitOfWork _uow;

        public UsuarioController(IUsuarioRepository repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        // GET: api/Empresa
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            try
            {
                var lst = await _repository.GetAll();
                return CustomSuccessResponse(200, "Usuários obtidos com sucesso", lst);                
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: api/Empresa/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var obj = await _repository.GetById(id);

                return obj == null ? NotFound() : Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT: api/Empresa/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Usuario obj)
        {
            try
            {
                if (id != obj.Id)
                    return BadRequest();

                _repository.Update(obj);
                await _uow.Commit();

                return Ok(await Get(obj.Id));
            }
            catch (Exception ex)
            {
                await _uow.Rollback();
                return BadRequest(ex);
            }
        }

        // POST: api/Empresa
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> Post(Usuario obj)
        {
            try
            {
                await _repository.Add(obj);
                await _uow.Commit();

                obj = await _repository.GetById(obj.Id);

                return CustomSuccessResponse(201, "Usuário criado com sucesso", obj);                
            }
            catch (Exception ex)
            {
                await _uow.Rollback();
                return BadRequest(ex);
            }
        }

        // DELETE: api/Empresa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _repository.Remove(await _repository.GetById(id));
                await _uow.Commit();

                return NoContent();
            }
            catch (Exception ex)
            {
                await _uow.Rollback();
                return BadRequest(ex);
            }
        }

        private async Task<bool> Exists(int id) =>
            await _repository.Exists(id);

        [HttpPost("login")]
        public async Task<ActionResult<Usuario>> Login(Usuario obj)
        {
            try
            {
                var usuario = await _repository.Login(obj);

                if (usuario == null)
                    return CustomFailResponse(404, "Usuário ou senha inválidos");                    

                usuario.Token = Services.TokenService.GenerateToken(usuario, DateTime.UtcNow.AddHours(2));

                return CustomSuccessResponse(200, "Login realizado com sucesso", usuario);                
            }
            catch (Exception ex)
            {
                await _uow.Rollback();                
                return CustomFailResponse(400, ex.InnerException?.Message ?? ex?.Message);
            }
        }
    }
}
