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
    public class PerfilController : MainController
    {
        private readonly IPerfilRepository _repository;
        private readonly IUnitOfWork _uow;

        public PerfilController(IPerfilRepository repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        // GET: api/Empresa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Perfil>>> Get()
        {
            var lst = await _repository.GetAll();

            return CustomSuccessResponse(StatusCodes.Status200OK, "Perfis obtidas com sucesso", lst);
        }

        [HttpGet("ObterComFuncoes")]
        public async Task<ActionResult<IEnumerable<Perfil>>> ObterComFuncoes()
        {
            var lst = await _repository.ObterComFuncoes();

            return CustomSuccessResponse(StatusCodes.Status200OK, "Perfis obtidas com sucesso", lst);
        }

        // GET: api/Empresa/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Perfil>> Get(int id)
        {
            var obj = await _repository.GetById(id);

            return obj == null ? CustomErrorResponse(StatusCodes.Status404NotFound, "Perfil não encontrado") : CustomSuccessResponse(StatusCodes.Status200OK, "Perfil obtido com sucesso", obj);
        }

        // PUT: api/Empresa/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Perfil>> Put(int id, Perfil obj, [FromServices] PerfilValidator validator)
        {
            if (id != obj.Id)
                return CustomErrorResponse(StatusCodes.Status400BadRequest, "O Id passado na url é diferente do Id do objeto");

            var result = await validator.ValidateAsync(obj);

            if (!result.IsValid)
                return CustomErrorResponse(StatusCodes.Status400BadRequest, "", result.Errors);

            _repository.Update(obj);
            await _uow.Commit();

            return CustomSuccessResponse(StatusCodes.Status200OK, "Perfil atualizado com sucesso", obj);
        }

        // POST: api/Empresa
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Perfil>> Post(Perfil obj, [FromServices] PerfilValidator validator)
        {
            var result = await validator.ValidateAsync(obj);

            if (!result.IsValid)
                return CustomErrorResponse(StatusCodes.Status400BadRequest, "", result.Errors);

            await _repository.Add(obj);
            await _uow.Commit();

            obj = await _repository.GetById(obj.Id);

            return CustomSuccessResponse(StatusCodes.Status201Created, "Perfil inserido com sucesso", obj);
        }

        // DELETE: api/Empresa/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Perfil>> Delete(int id)
        {
            var obj = await _repository.GetById(id);

            if (obj == null)
                return CustomErrorResponse(StatusCodes.Status404NotFound, "Perfil não encontrado");

            _repository.Remove(obj);
            await _uow.Commit();

            return CustomSuccessResponse(StatusCodes.Status200OK, "Perfil excluído com sucesso", obj);
        }

        private async Task<bool> Exists(int id) =>
            await _repository.Exists(id);
    }
}
