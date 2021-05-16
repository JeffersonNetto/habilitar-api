using AutoMapper;
using Habilitar.Core.Helpers;
using Habilitar.Core.Models;
using Habilitar.Core.Repositories;
using Habilitar.Core.Services;
using Habilitar.Core.Uow;
using Habilitar.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Habilitar.Api.Controllers
{    
    public class PessoaController : MainController
    {
        private readonly IPessoaRepository _repository;
        private readonly IPessoaService _service;
        private readonly IMapper _mapper;

        public PessoaController(
            INotificador notificador,
            IPessoaRepository repository,
            IPessoaService service,
            IUser user, 
            IMapper mapper) : base(notificador, user)
        {
            _repository = repository;
            _service = service;
            _mapper = mapper;
        }

        //[HttpGet("combo")]
        //public async Task<IActionResult> GetCombo()
        //{
        //    var lst = await _service.ObterCombos();

        //    return CustomResponse(lst);
        //}

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lst = await _repository.ObterComUsuario();

            var result = _mapper.Map<IEnumerable<PessoaViewModelUpdate>>(lst);

            return CustomResponse(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var obj = await _repository.GetById(id);

            return obj == null ? NotFound() : CustomResponse(obj);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, Pessoa obj)
        {
            obj.UsuarioAtualizacaoId = UsuarioId;
            await _service.Atualizar(obj);

            return CustomResponse(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Pessoa obj)
        {
            obj.UsuarioCriacaoId = UsuarioId;
            await _service.Adicionar(obj);

            return CustomResponse(obj);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Remover(id);

            return CustomResponse();
        }

        private async Task<bool> Exists(int id) =>
            await _repository.Exists(id);
    }
}
