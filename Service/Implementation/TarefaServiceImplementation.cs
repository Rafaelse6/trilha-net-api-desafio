using TrilhaApiDesafio.Models;
using TrilhaApiDesafio.Repository.Generic;

namespace TrilhaApiDesafio.Service.Implementation
{
    public class TarefaServiceImplementation : ITarefaService
    {
        private readonly IRepository<Tarefa> _repository;

        public TarefaServiceImplementation(IRepository<Tarefa> repository)
        {
            _repository = repository;
        }

        public List<Tarefa> FindAll()
        {
            return _repository.FindAll();
        }

        public Tarefa FindById(int id)
        {
            return _repository.FindById(id);
        }

        public Tarefa Create(Tarefa tarefa)
        {
            return _repository.Create(tarefa);
        }

        public Tarefa Update(Tarefa tarefa)
        {
            return _repository.Update(tarefa);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<Tarefa> FindByDate(DateTime date)
        {
            return _repository.FindAll().FindAll(t => t.Data.Date == date.Date);
        }


        public List<Tarefa> FindByStatus(EnumStatusTarefa status)
        {
            return _repository.FindAll().FindAll(t => t.Status == status);
        }

        public Tarefa FindByTitle(string title)
        {
            return _repository.FindAll().Find(t => t.Titulo == title);
        }


    }
}
