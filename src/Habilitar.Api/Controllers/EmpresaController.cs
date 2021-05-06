using Habilitar.Core.Helpers;
using Habilitar.Core.Models;
using Habilitar.Core.Repositories;
using Habilitar.Core.Services;
using Habilitar.Core.Uow;
using Habilitar.Core.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Habilitar.Api.Controllers
{
    public class EmpresaController : MainController
    {
        private readonly IRepositoryBase<Empresa> _repository;
        private readonly IEmpresaService _service;
        private readonly IUnitOfWork _uow;

        public EmpresaController(
            INotificador notificador,
            IRepositoryBase<Empresa> repository,
            IEmpresaService service,
            IUser user,
            IUnitOfWork uow) : base(notificador, user)
        {
            _repository = repository;
            _service = service;
            _uow = uow;
        }

        // GET: api/Empresa
        [HttpGet]        
        public async Task<ActionResult<IEnumerable<Empresa>>> Get()
        {            
            var lst = await _repository.GetAll();

            return CustomSuccessResponse(StatusCodes.Status200OK, "Empresas obtidas com sucesso", lst);
        }

        // GET: api/Empresa/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Empresa>> Get(int id)
        {
            var obj = await _repository.GetById(id);

            return obj == null ? CustomErrorResponse(StatusCodes.Status404NotFound, "Empresa não encontrada") : CustomSuccessResponse(StatusCodes.Status200OK, "Empresa obtida com sucesso", obj);
        }

        // PUT: api/Empresa/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Empresa>> Put(int id, Empresa obj, [FromServices] EmpresaValidator validator)
        {
            if (id != obj.Id)
                return CustomErrorResponse(StatusCodes.Status400BadRequest, "O Id passado na url é diferente do Id do objeto");

            var result = await validator.ValidateAsync(obj);

            if (!result.IsValid)
                return CustomErrorResponse(StatusCodes.Status400BadRequest, "", result.Errors);

            _repository.Update(obj);
            await _uow.Commit();

            return CustomSuccessResponse(StatusCodes.Status200OK, "Empresa atualizada com sucesso", obj);
        }

        // POST: api/Empresa
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Empresa>> Post(Empresa obj, [FromServices] EmpresaValidator validator)
        //{
        //    var result = await validator.ValidateAsync(obj);

        //    if (!result.IsValid)
        //        return CustomErrorResponse(StatusCodes.Status400BadRequest, "", result.Errors);

        //    await _repository.Add(obj);
        //    await _uow.Commit();

        //    obj = await _repository.GetById(obj.Id);

        //    return CustomSuccessResponse(StatusCodes.Status201Created, "Empresa inserida com sucesso", obj);
        //}

        [HttpPost]
        public async Task<ActionResult<Empresa>> Post(Empresa obj)
        {
            //if (!ModelState.IsValid)
            //    return CustomResponse(ModelState);            
            await _service.Adicionar(obj);            

            return CustomResponse(obj);
        }

        // DELETE: api/Empresa/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Empresa>> Delete(int id)
        {
            var obj = await _repository.GetById(id);

            if (obj == null)
                return CustomErrorResponse(StatusCodes.Status404NotFound, "Empresa não encontrada");

            _repository.Remove(obj);
            await _uow.Commit();

            return CustomSuccessResponse(StatusCodes.Status200OK, "Empresa excluída com sucesso", obj);
        }

        private async Task<bool> Exists(int id) =>
            await _repository.Exists(id);
    }
}
