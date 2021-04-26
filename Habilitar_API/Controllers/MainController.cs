using FluentValidation.Results;
using Habilitar_API.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Habilitar_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class MainController : ControllerBase
    {
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
