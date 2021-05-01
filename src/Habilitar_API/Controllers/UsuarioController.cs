using AutoMapper;
using Habilitar_API.ViewModels;
using Habilitar_API.Models;
using Habilitar_API.Repositories;
using Habilitar_API.Uow;
using Habilitar_API.Validators;
using Microsoft.AspNetCore.Http;
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
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioRepository repository, IUnitOfWork uow, IMapper mapper)
        {
            _repository = repository;
            _uow = uow;
            _mapper = mapper;
        }

        // GET: api/Empresa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> Get()
        {
            var lst = await _repository.GetAll();

            return CustomSuccessResponse(StatusCodes.Status200OK, "Usuários obtidos com sucesso", lst);
        }

        [HttpGet("ObterComPerfis")]
        public async Task<ActionResult<IEnumerable<Usuario>>> ObterComPerfis()
        {
            var lst = await _repository.ObterComPerfis();

            return CustomSuccessResponse(StatusCodes.Status200OK, "Usuários obtidos com sucesso", lst);
        }

        // GET: api/Empresa/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<UsuarioViewModel>> Get(int id)
        {
            var obj = await _repository.ObterComPerfis(id);

            var usuarioViewModel = _mapper.Map<Usuario, UsuarioViewModel>(obj);

            return obj == null ? CustomErrorResponse(StatusCodes.Status404NotFound, "Usuário não encontrado") : CustomSuccessResponse(StatusCodes.Status200OK, "Usuário obtido com sucesso", usuarioViewModel);
        }

        // PUT: api/Empresa/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Usuario>> Put(int id, Usuario obj, [FromServices] UsuarioValidator validator)
        {
            if (id != obj.Id)
                return CustomErrorResponse(StatusCodes.Status400BadRequest, "O Id passado na url é diferente do Id do objeto");

            var result = await validator.ValidateAsync(obj);

            if (!result.IsValid)
                return CustomErrorResponse(StatusCodes.Status400BadRequest, "", result.Errors);

            _repository.Update(obj);
            await _uow.Commit();

            return CustomSuccessResponse(StatusCodes.Status200OK, "Usuário atualizado com sucesso", obj);
        }

        // POST: api/Empresa
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuario>> Post(Usuario obj, [FromServices] UsuarioValidator validator)
        {
            var result = await validator.ValidateAsync(obj);

            if (!result.IsValid)
                return CustomErrorResponse(StatusCodes.Status400BadRequest, "", result.Errors);

            await _repository.Add(obj);
            await _uow.Commit();

            obj = await _repository.GetById(obj.Id);

            return CustomSuccessResponse(StatusCodes.Status201Created, "Usuário inserido com sucesso", obj);
        }

        // DELETE: api/Empresa/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Usuario>> Delete(int id)
        {
            var obj = await _repository.GetById(id);

            if (obj == null)
                return CustomErrorResponse(StatusCodes.Status404NotFound, "Usuário não encontrado");

            _repository.Remove(obj);
            await _uow.Commit();

            return CustomSuccessResponse(StatusCodes.Status200OK, "Usuário excluído com sucesso", obj);
        }

        private async Task<bool> Exists(int id) =>
            await _repository.Exists(id);

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioViewModel>> Login(LoginViewModel obj)
        {
            var usuario = await _repository.Login(obj.Login, obj.Senha);

            if (usuario == null)
                return CustomErrorResponse(StatusCodes.Status404NotFound, "Usuário ou senha inválidos");

            usuario.Token = Services.TokenService.GenerateToken(usuario, DateTime.UtcNow.AddHours(2));

            var usuarioViewModel = _mapper.Map<Usuario, UsuarioViewModel>(usuario);

            return CustomSuccessResponse(StatusCodes.Status200OK, "Login realizado com sucesso", usuarioViewModel);
        }
    }
}
