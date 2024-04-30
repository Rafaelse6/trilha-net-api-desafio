using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Service
{
    public interface ITarefaService
    {
        Tarefa Create(Tarefa tarefa);
        Tarefa FindById(int id);
        List<Tarefa> FindAll();
        Tarefa Update(Tarefa tarefa);
        Tarefa FindByTitle(string title);
        List<Tarefa> FindByDate(DateTime date);
        List<Tarefa> FindByStatus(EnumStatusTarefa status);
        void Delete(int id);
    }
}
