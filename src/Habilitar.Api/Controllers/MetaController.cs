using Habilitar.Core.Helpers;
using Habilitar.Core.Models;
using Habilitar.Core.Repositories;
using Habilitar.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Habilitar.Api.Controllers
{
    public class MetaController : MainController
    {
        private readonly IRepositoryBase<Meta> _repository;
        private readonly IMetaService _service;
        
        public MetaController(
            INotificador notificador,
            IRepositoryBase<Meta> repository,
            IMetaService service,
            IUser user
            ) : base(notificador, user)
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
        public async Task<IActionResult> Put(int id, Meta obj)
        {
            obj.DataAtualizacao = DateTime.Now;
            obj.UsuarioAtualizacaoId = UsuarioId;
            await _service.Atualizar(obj);

            return CustomResponse(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Meta obj)
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
