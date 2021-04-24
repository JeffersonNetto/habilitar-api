using Habilitar_API.Models;
using Habilitar_API.Repositories;
using Habilitar_API.Uow;
using Habilitar_API.Validators;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Habilitar_API.Controllers
{    
    public class EmpresaController : MainController
    {
        private readonly IRepositoryBase<Empresa> _repository;
        private readonly IUnitOfWork _uow;

        public EmpresaController(IRepositoryBase<Empresa> repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        // GET: api/Empresa
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var lst = await _repository.GetAll();

                return Ok(lst);
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
        public async Task<IActionResult> Put(int id, Empresa obj)
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
        public async Task<IActionResult> Post(Empresa obj, [FromServices] EmpresaValidator empresaValidator)
        {
            try
            {
                var result = await empresaValidator.ValidateAsync(obj);

                if (!result.IsValid)
                    return CustomFailResponse(400, "", result.Errors);

                await _repository.Add(obj);
                await _uow.Commit();

                return Created("Post", await _repository.GetById(obj.Id));                
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
    }
}
