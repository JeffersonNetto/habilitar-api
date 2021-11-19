using FluentValidation.Results;
using Habilitar.Core.Helpers;
using Habilitar.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Habilitar.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificador _notificador;
        protected readonly IUser AppUser;

        protected Guid UsuarioId { get; set; }
        protected bool UsuarioAutenticado { get; set; }

        protected MainController(
            INotificador notificador,
            IUser appUser
            )
        {
            _notificador = notificador;
            AppUser = appUser;

            if (appUser.IsAuthenticated())
            {
                UsuarioId = appUser.GetUserId();
                UsuarioAutenticado = true;
            }
        }

        protected void NotificarErro(string mensagem) => _notificador.Handle(new Notificacao(mensagem));
        protected bool OperacaoValida() => !_notificador.TemNotificacao();

        protected ActionResult CustomResponse(object dados = null)
        {
            if (!OperacaoValida())
            {
                return BadRequest(new
                {
                    Erros = _notificador.ObterNotificacoes().Select(n => n.Mensagem)
                });
            }

            return Ok(new
            {
                Dados = dados,
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModelInvalida(modelState);
            return CustomResponse();
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(errorMsg);
            }
        }

        protected ActionResult<T> CustomSuccessResponse<T>(int statusCode = StatusCodes.Status200OK, string mensagem = null, T dados = null) where T : class
        {
            var result = statusCode switch
            {
                200 => CustomOkResponse(mensagem, dados),
                201 => CustomCreatedResponse(mensagem, dados),
                _ => null,
            };

            return result;
        }

        protected ActionResult CustomErrorResponse(int statusCode = StatusCodes.Status400BadRequest, string mensagem = null, List<ValidationFailure> validationFailures = null)
        {
            var result = statusCode switch
            {
                400 => CustomBadRequestResponse(mensagem, validationFailures),
                404 => CustomNotFoundResponse(mensagem),
                _ => null,
            };

            return result;
        }

        private ActionResult CustomNotFoundResponse(string mensagem) =>
            NotFound(new ErrorResponse { Mensagem = mensagem });

        private ActionResult CustomBadRequestResponse(string mensagem, List<ValidationFailure> validationFailures) =>
            BadRequest(new ErrorResponse(validationFailures) { Mensagem = mensagem });

        private ActionResult<T> CustomCreatedResponse<T>(string mensagem, T dados) =>
            Created("", new SuccessResponse<T> { Mensagem = mensagem, Dados = dados });

        private ActionResult<T> CustomOkResponse<T>(string mensagem, T dados) =>
            Ok(new SuccessResponse<T> { Mensagem = mensagem, Dados = dados });
    }
}
