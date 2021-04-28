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
    public class UnidadeController : MainController
    {
        private readonly IRepositoryBase<Unidade> _repository;
        private readonly IUnitOfWork _uow;        

        public UnidadeController(IRepositoryBase<Unidade> repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;            
        }

        // GET: api/Unidade
        [HttpGet]
        public async Task<ActionResult<List<Unidade>>> Get()
        {
            var lst = await _repository.GetAll();

            return CustomSuccessResponse(StatusCodes.Status200OK, "Unidades obtidas com sucesso", lst);
        }

        // GET: api/Unidade/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Unidade>> Get(int id)
        {
            var obj = await _repository.GetById(id);

            return obj == null ? CustomErrorResponse(StatusCodes.Status404NotFound, "Unidade não encontrada") : CustomSuccessResponse(StatusCodes.Status200OK, "Unidade obtida com sucesso", obj);
        }

        // PUT: api/Unidade/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Unidade>> Put(int id, Unidade obj, [FromServices] UnidadeValidator validator)
        {
            if (id != obj.Id)
                return CustomErrorResponse(StatusCodes.Status400BadRequest, "O Id passado na url é diferente do Id do objeto");

            var result = await validator.ValidateAsync(obj);

            if (!result.IsValid)
                return CustomErrorResponse(StatusCodes.Status400BadRequest, "", result.Errors);

            _repository.Update(obj);
            await _uow.Commit();

            return CustomSuccessResponse(StatusCodes.Status200OK, "Unidade atualizada com sucesso", obj);
        }

        // POST: api/Unidade
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Unidade>> Post(Unidade obj, [FromServices] UnidadeValidator validator)
        {
            var result = await validator.ValidateAsync(obj);

            if (!result.IsValid)
                return CustomErrorResponse(StatusCodes.Status400BadRequest, "", result.Errors);

            await _repository.Add(obj);
            await _uow.Commit();

            obj = await _repository.GetById(obj.Id);

            return CustomSuccessResponse(StatusCodes.Status201Created, "Unidade inserida com sucesso", obj);
        }

        // DELETE: api/Unidade/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Unidade>> Delete(int id)
        {
            var obj = await _repository.GetById(id);

            if (obj == null)
                return CustomErrorResponse(StatusCodes.Status404NotFound, "Unidade não encontrada");

            _repository.Remove(obj);
            await _uow.Commit();

            return CustomSuccessResponse(StatusCodes.Status200OK, "Unidade excluída com sucesso", obj);
        }

        private async Task<bool> Exists(int id) =>
            await _repository.Exists(id);
    }
}
