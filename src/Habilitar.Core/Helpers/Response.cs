using FluentValidation.Results;
using System.Collections.Generic;

namespace Habilitar.Core.Helpers
{
    public abstract record Response
    {        
        public string Mensagem { get; init; }                        
    }

    public record SuccessResponse<T> : Response
    {
        public T Dados { get; init; }
    }

    public record ErrorResponse : Response
    {
        public ErrorResponse(List<ValidationFailure> validationFailure = null) =>
            ConvertErrors(validationFailure);

        public ErrorResponse(string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(errorMessage))
                Mensagem = "Sistema temporariamente indisponível. Tente novamente mais tarde.";
            else if (errorMessage.ToLower().Contains("uq_cpf"))
                Erros.Add("O CPF informado já está cadastrado na base de dados");
            else if (errorMessage.ToLower().Contains("uq_email"))
                Erros.Add("O e-mail informado já está cadastrado na base de dados");
        }
        
        public List<string> Erros { get; private init; } = new List<string>();

        private void ConvertErrors(List<ValidationFailure> validationFailure) =>
            validationFailure?.ForEach(_ => Erros.Add(_.ErrorMessage));
    }
}
