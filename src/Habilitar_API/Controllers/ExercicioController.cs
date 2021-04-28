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
    public class ExercicioController : MainController
    {
        private readonly IRepositoryBase<Exercicio> _repository;
        private readonly IUnitOfWork _uow;        

        public ExercicioController(IRepositoryBase<Exercicio> repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        // GET: api/Exercicio
        [HttpGet]
        public async Task<ActionResult<List<Exercicio>>> Get()
        {
            var lst = await _repository.GetAll();

            return CustomSuccessResponse(StatusCodes.Status200OK, "Exercícios obtidos com sucesso", lst);
        }

        // GET: api/Exercicio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exercicio>> Get(int id)
        {

            var obj = await _repository.GetById(id);

            return obj == null ? CustomErrorResponse(StatusCodes.Status404NotFound, "Exercício não encontrado") : CustomSuccessResponse(StatusCodes.Status200OK, "Exercício obtido com sucesso", obj);
        }

        // PUT: api/Exercicio/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Exercicio>> Put(int id, Exercicio obj, [FromServices] ExercicioValidator validator)
        {
            if (id != obj.Id)
                return CustomErrorResponse(StatusCodes.Status400BadRequest, "O Id passado na url é diferente do Id do objeto");

            var result = await validator.ValidateAsync(obj);

            if (!result.IsValid)
                return CustomErrorResponse(StatusCodes.Status400BadRequest, "", result.Errors);

            _repository.Update(obj);
            await _uow.Commit();

            return CustomSuccessResponse(StatusCodes.Status200OK, "Exercício atualizado com sucesso", obj);
        }

        // POST: api/Exercicio
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Exercicio>> Post(Exercicio obj, [FromServices] ExercicioValidator validator)
        {
            var result = await validator.ValidateAsync(obj);

            if (!result.IsValid)
                return CustomErrorResponse(StatusCodes.Status400BadRequest, "", result.Errors);

            await _repository.Add(obj);
            await _uow.Commit();

            obj = await _repository.GetById(obj.Id);

            return CustomSuccessResponse(StatusCodes.Status201Created, "Exercício inserido com sucesso", obj);
        }

        // DELETE: api/Exercicio/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Exercicio>> Delete(int id)
        {
            var obj = await _repository.GetById(id);

            if (obj == null)
                return CustomErrorResponse(StatusCodes.Status404NotFound, "Exercício não encontrado");

            _repository.Remove(obj);
            await _uow.Commit();

            return CustomSuccessResponse(StatusCodes.Status200OK, "Exercício excluído com sucesso", obj);
        }

        private async Task<bool> Exists(int id) =>
            await _repository.Exists(id);
    }
}
