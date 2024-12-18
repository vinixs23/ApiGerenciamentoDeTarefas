using ApiGerenciamentoDeTarefas.Models;

namespace ApiGerenciamentoDeTarefas.Repository
{
    public interface ITarefaRepository
    {
        Task<IEnumerable<Tarefa>> GetAllAsync();
        Task<Tarefa> GetByIdAsync(int id);
        Task AddAsync(Tarefa tarefa);
        Task<bool> UpdateAsync(Tarefa tarefa);
        Task DeleteAsync(int id);
    }
}