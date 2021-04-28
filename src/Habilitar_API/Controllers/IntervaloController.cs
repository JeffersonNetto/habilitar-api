using Habilitar_API.Models;
using Habilitar_API.Repositories;
using Habilitar_API.Uow;
using Habilitar_API.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Habilitar_API.Controllers
{
    public class IntervaloController : MainController
    {
        private readonly IRepositoryBase<Intervalo> _repository;
        private readonly IUnitOfWork _uow;
        private readonly IntervaloValidator _validator;

        public IntervaloController(IRepositoryBase<Intervalo> repository, IUnitOfWork uow, IntervaloValidator validator)
        {
            _repository = repository;
            _uow = uow;
            _validator = validator;
        }

        // GET: api/Empresa
        [HttpGet]
        public async Task<ActionResult<List<Intervalo>>> Get()
        {
            var lst = await _repository.GetAll();

            return CustomSuccessResponse(StatusCodes.Status200OK, "Intervalos obtidos com sucesso", lst);
        }

        // GET: api/Empresa/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Intervalo>> Get(int id)
        {
            var obj = await _repository.GetById(id);

            return obj == null ? CustomErrorResponse(StatusCodes.Status404NotFound, "Intervalo não encontrado") : CustomSuccessResponse(StatusCodes.Status200OK, "Intervalo obtido com sucesso", obj);
        }

        // PUT: api/Empresa/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Intervalo>> Put(int id, Intervalo obj)
        {
            if (id != obj.Id)
                return CustomErrorResponse(StatusCodes.Status400BadRequest, "O Id passado na url é diferente do Id do objeto");

            var result = await _validator.ValidateAsync(obj);

            if (!result.IsValid)
                return CustomErrorResponse(StatusCodes.Status400BadRequest, "", result.Errors);

            _repository.Update(obj);
            await _uow.Commit();

            return CustomSuccessResponse(StatusCodes.Status200OK, "Intervalo atualizado com sucesso", obj);
        }

        // POST: api/Empresa
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Intervalo>> Post(Intervalo obj)
        {
            var result = await _validator.ValidateAsync(obj);

            if (!result.IsValid)
                return CustomErrorResponse(StatusCodes.Status400BadRequest, "", result.Errors);

            await _repository.Add(obj);
            await _uow.Commit();

            obj = await _repository.GetById(obj.Id);

            return CustomSuccessResponse(StatusCodes.Status201Created, "Intervalo inserido com sucesso", obj);
        }

        // DELETE: api/Empresa/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Intervalo>> Delete(int id)
        {
            var obj = await _repository.GetById(id);

            if (obj == null)
                return CustomErrorResponse(StatusCodes.Status404NotFound, "Intervalo não encontrado");

            _repository.Remove(obj);
            await _uow.Commit();

            return CustomSuccessResponse(StatusCodes.Status200OK, "Intervalo excluído com sucesso", obj);
        }

        private async Task<bool> Exists(int id) =>
            await _repository.Exists(id);
    }
}
