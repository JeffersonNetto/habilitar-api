﻿using Habilitar.Core.Helpers;
using Habilitar.Core.Models;
using Habilitar.Core.Repositories;
using Habilitar.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Habilitar.Api.Controllers
{
    public class ExercicioController : MainController
    {
        private readonly IRepositoryBase<Exercicio> _repository;
        private readonly IExercicioService _service;

        public ExercicioController(
            INotificador notificador,
            IRepositoryBase<Exercicio> repository,
            IExercicioService service,
            IUser user) : base(notificador, user)
        {
            _repository = repository;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lst = await _repository.GetAll();

            return CustomResponse(lst);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var obj = await _repository.GetById(id);

            return obj == null ? NotFound() : CustomResponse(obj);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, Exercicio obj)
        {
            obj.UsuarioAtualizacaoId = UsuarioId;
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