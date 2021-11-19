using AutoMapper;
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
        private readonly IMapper _mapper;

        public UsuarioController(
            INotificador notificador,
            IUser user,
            IUsuarioService usuarioService,
            IUsuarioRepository usuarioRepository, IMapper mapper) : base(notificador, user)
        {
            _usuarioService = usuarioService;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        [HttpGet("combo/{role:int}")]
        public async Task<IActionResult> GetCombo(Core.Enums.Role role)
        {
            var lst = await _usuarioService.ObterCombo(role);

            return CustomResponse(lst);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            CustomResponse(await _usuarioRepository.Obter());

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id) =>
            CustomResponse(await _usuarioRepository.ObterPorId(id));

        [HttpPost]
        public async Task<IActionResult> Post(CreateUserViewModel user)
        {
            user.UsuarioCriacaoId = UsuarioId;

            await _usuarioService.Adicionar(_mapper.Map<User>(user), user.Role);         

            return CustomResponse();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<LoginResponseViewModel>> Editar(Guid id, User user)
        {
            user.UsuarioAtualizacaoId = UsuarioId;

            await _usuarioService.Atualizar(user);
            
            return CustomResponse();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Remover(Guid id)
        {
            await _usuarioService.Remover(id);

            return CustomResponse();
        }

        [HttpPut("alterar-senha/{id:guid}")]
        public async Task<IActionResult> AlterarSenha(Guid id, AlterarSenhaViewModel model)
        {
            await _usuarioService.AlterarSenha(id, model);

            return CustomResponse();
        }

        [HttpGet("perfil/{id:guid}")]
        public async Task<string> GetUserRole(Guid id)
        {
            return await _usuarioService.ObterRole(id);
        }
    }
}
