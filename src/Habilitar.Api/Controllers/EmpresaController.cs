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
        
        [HttpGet]        
        public async Task<ActionResult<IEnumerable<Empresa>>> Get()
        {            
            var lst = await _repository.GetAll();

            return CustomResponse(lst);
        }
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Empresa>> Get(int id)
        {
            var obj = await _repository.GetById(id);

            return obj == null ? NotFound() : CustomResponse(obj);
        }
        
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Empresa>> Put(int id, Empresa obj)
        {
            await _service.Atualizar(obj);            

            return CustomResponse(obj);
        }

        [HttpPost]
        public async Task<ActionResult<Empresa>> Post(Empresa obj)
        {                   
            await _service.Adicionar(obj);            

            return CustomResponse(obj);
        }
        
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Empresa>> Delete(int id)
        {
            await _service.Remover(id);

            return CustomResponse();
        }

        private async Task<bool> Exists(int id) =>
            await _repository.Exists(id);
    }
}
