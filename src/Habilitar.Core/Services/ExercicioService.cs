using Habilitar.Core.Models;
using Habilitar.Core.Repositories;
using Habilitar.Core.Uow;
using Habilitar.Core.Validators;
using System;
using System.Threading.Tasks;

namespace Habilitar.Core.Services
{
    public interface IExercicioService : IDisposable
    {
        Task<bool> Adicionar(Exercicio obj);
        Task<bool> Atualizar(Exercicio obj);
        Task<bool> Remover(int id);
    }

    public class ExercicioService : ServiceBase, IExercicioService
    {
        private readonly IRepositoryBase<Exercicio> _exercicioRepository;

        public ExercicioService(
            INotificador notificador,
            IUnitOfWork uow,
            IRepositoryBase<Exercicio> exercicioRepository) : base(notificador, uow) => _exercicioRepository = exercicioRepository;

        public async Task<bool> Adicionar(Exercicio obj)
        {
            if (!await ExecutarValidacao(new ExercicioValidator(), obj))
                return false;

            await _exercicioRepository.Add(obj);
            await Commit();

            return true;
        }

        public async Task<bool> Atualizar(Exercicio obj)
        {
            if (!await ExecutarValidacao(new ExercicioValidator(), obj))
                return false;

            _exercicioRepository.Update(obj);
            await Commit();

            return true;
        }

        public async Task<bool> Remover(int id)
        {
            var empresa = await _exercicioRepository.GetById(id);

            if (empresa == null)
                Notificar($"Nenhum exercício encontrado para o Id {id}");

            _exercicioRepository.Remove(empresa);
            await Commit();

            return true;
        }

        public void Dispose() => _exercicioRepository?.Dispose();
    }
}
