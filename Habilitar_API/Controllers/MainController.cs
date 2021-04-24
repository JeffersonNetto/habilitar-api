using FluentValidation.Results;
using Habilitar_API.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Habilitar_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]        
    public abstract class MainController : ControllerBase
    {        
        protected ActionResult<T> CustomSuccessResponse<T>(int statusCode, string mensagem, T dados = null) where T : class
        {
            ActionResult<T> result = null;

            switch (statusCode)
            {
                case 200:
                    result = CustomOkResponse(mensagem, dados);
                    break;
                case 201:
                    result = CustomCreatedResponse(mensagem, dados);
                    break;
            }

            return result;
        }

        protected ActionResult CustomFailResponse(int statusCode, string mensagem, List<ValidationFailure> validationFailures = null)
        {
            ActionResult result = null;

            switch (statusCode)
            {
                case 400:
                    result = CustomBadRequestResponse(mensagem, validationFailures);
                    break;
                case 404:
                    result = CustomNotFoundResponse(mensagem);
                    break;
            }

            return result;
        }

        private ActionResult CustomNotFoundResponse(string mensagem)
        {
            return NotFound(new FailResponse { Mensagem = mensagem });
        }

        private ActionResult CustomBadRequestResponse(string mensagem, List<ValidationFailure> validationFailures)
        {
            return BadRequest(new FailResponse(validationFailures) { Mensagem = mensagem });
        }

        private ActionResult<T> CustomCreatedResponse<T>(string mensagem, T dados)
        {
            return Created("", new SuccessResponse<T> { Mensagem = mensagem, Dados = dados });
        }

        private ActionResult<T> CustomOkResponse<T>(string mensagem, T dados)
        {
            return Ok(new SuccessResponse<T> { Mensagem = mensagem, Dados = dados });            
        }
    }
}
