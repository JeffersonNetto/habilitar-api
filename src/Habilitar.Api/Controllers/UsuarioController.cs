using Habilitar.Core.Helpers;
using Habilitar.Core.Models;
using Habilitar.Core.Repositories;
using Habilitar.Core.Services;
using Habilitar.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Habilitar.Api.Controllers
{
    public class UsuarioController : MainController
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(
            INotificador notificador,
            IUser user,
            IUsuarioService usuarioService, 
            IUsuarioRepository usuarioRepository) : base(notificador, user)
        {
            _usuarioService = usuarioService;
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            CustomResponse(await _usuarioRepository.Obter());

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id) =>
            CustomResponse(await _usuarioRepository.ObterPorId(id));

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            await _usuarioService.Adicionar(user);         

            return CustomResponse();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<LoginResponseViewModel>> Editar(Guid id, User user)
        {
            await _usuarioService.Atualizar(user);
            
            return CustomResponse();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Remover(Guid id)
        {
            await _usuarioService.Remover(id);

            return CustomResponse();
        }
    }
}
