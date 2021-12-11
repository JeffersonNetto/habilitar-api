using Habilitar.Core.Helpers;
using Habilitar.Core.Models;
using Habilitar.Core.Repositories;
using Habilitar.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Habilitar.Api.Controllers
{
    public class GrupoController : MainController
    {
        private readonly IGrupoRepository _repository;
        private readonly IGrupoService _service;

        public GrupoController(
            INotificador notificador,
            IGrupoRepository repository,
            IGrupoService service,
            IUser user) : base (notificador, user)
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

        // GET: api/Unidade
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var lst = await _repository.GetAll();

            return CustomResponse(lst);
        }

        // GET: api/Unidade/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var obj = await _repository.GetById(id);

            return obj == null ? NotFound() : CustomResponse(obj);
        }

        // PUT: api/Unidade/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Grupo obj)
        {
            obj.UsuarioAtualizacaoId = UsuarioId;
            await _service.Atualizar(obj);

            return CustomResponse(obj);
        }

        // POST: api/Unidade
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> Post(Grupo obj)
        {
            obj.UsuarioCriacaoId = UsuarioId;
            await _service.Adicionar(obj);

            return CustomResponse(obj);
        }

        // DELETE: api/Unidade/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Remover(id);

            return CustomResponse();
        }

        private async Task<bool> Exists(int id) =>
            await _repository.Exists(id);
    }
}
