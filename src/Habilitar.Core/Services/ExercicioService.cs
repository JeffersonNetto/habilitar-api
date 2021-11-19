using Habilitar.Core.Models;
using Habilitar.Core.Repositories;
using Habilitar.Core.Uow;
using Habilitar.Core.Validators;
using Habilitar.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Habilitar.Core.Services
{
    public interface IExercicioService : IDisposable
    {
        Task<bool> Adicionar(Exercicio obj);
        Task<bool> Atualizar(Exercicio obj);
        Task<bool> Remover(int id);
        Task<IEnumerable<ComboBase<int>>> ObterCombo();
    }

    public class ExercicioService : ServiceBase, IExercicioService
    {
        private readonly IExercicioRepository _exercicioRepository;

        public ExercicioService(
            INotificador notificador,
            IUnitOfWork uow,
            IExercicioRepository exercicioRepository) : base(notificador, uow) => _exercicioRepository = exercicioRepository;

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

        public async Task<IEnumerable<ComboBase<int>>> ObterCombo()
        {
            var lst = await _exercicioRepository.GetAll();            

            return lst.Select(obj => new ComboBase<int>
            {
                Value = obj.Id,
                Text = obj.Nome,
            });
        }
    }
}
