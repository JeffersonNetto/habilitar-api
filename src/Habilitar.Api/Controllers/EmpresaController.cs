using Habilitar.Core.Helpers;
using Habilitar.Core.Models;
using Habilitar.Core.Repositories;
using Habilitar.Core.Services;
using Habilitar.Core.Uow;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Habilitar.Api.Controllers
{
    public class EmpresaController : MainController
    {
        private readonly IRepositoryBase<Empresa> _repository;
        private readonly IEmpresaService _service;        

        public EmpresaController(
            INotificador notificador,
            IRepositoryBase<Empresa> repository,
            IEmpresaService service,
            IUser user) : base(notificador, user)
        {
            _repository = repository;
            _service = service;            
        }

        [HttpGet("combo")]
        public async Task<IActionResult> GetCombo()
        {
            var lst = await _service.ObterCombo();

            return CustomResponse(lst);
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
        public async Task<IActionResult> Put(int id, Empresa obj)
        {
            obj.UsuarioAtualizacaoId = UsuarioId;
            await _service.Atualizar(obj);            

            return CustomResponse(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Empresa obj)
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
