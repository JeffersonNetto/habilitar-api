using Habilitar.Core.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Habilitar.Core.Services
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }

    public class Notificador : INotificador
    {
        private readonly List<Notificacao> _notificacoes;
        public Notificador() => _notificacoes = new List<Notificacao>();        
        public void Handle(Notificacao notificacao) => _notificacoes.Add(notificacao);        
        public List<Notificacao> ObterNotificacoes() => _notificacoes;        
        public bool TemNotificacao() =>_notificacoes.Any();
    }
}
