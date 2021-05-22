using AutoMapper;
using Habilitar.Core.Helpers;
using Habilitar.Core.Models;
using Habilitar.Core.Repositories;
using Habilitar.Core.Services;
using Habilitar.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Habilitar.Api.Controllers
{
    public class ExercicioController : MainController
    {
        private readonly IExercicioRepository _repository;
        private readonly IExercicioService _service;
        private readonly IMapper _mapper;

        public ExercicioController(
            INotificador notificador,
            IExercicioRepository repository,
            IExercicioService service,            
            IMapper mapper,
            IUser user) : base(notificador, user)
        {
            _repository = repository;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lst = await _repository.ObterComGrupos();

            var result = _mapper.Map<IEnumerable<ExercicioViewModel>>(lst);
            
            return CustomResponse(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var obj = await _repository.ObterComGrupos(id);
            
            return obj == null ? NotFound() : CustomResponse(_mapper.Map<ExercicioViewModel>(obj));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, Exercicio obj)
        {
            obj.UsuarioAtualizacaoId = UsuarioId;
            obj.DataAtualizacao = DateTime.Now;

            await _service.Atualizar(obj);

            return CustomResponse(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Exercicio obj)
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
