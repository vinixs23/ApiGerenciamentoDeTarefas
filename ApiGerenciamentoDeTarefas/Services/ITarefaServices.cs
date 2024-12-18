using ApiGerenciamentoDeTarefas.Dtos;
using GerenciadorTarefas.Dtos;

namespace ApiGerenciamentoDeTarefas.Services
{
    public interface ITarefaService
    {
        Task<IEnumerable<TarefaReadDto>> GetAllAsync();
        Task<TarefaReadDto> GetByIdAsync(int id);
        Task<TarefaReadDto> CreateAsync(TarefaCreateDto tarefaDto);
        Task<bool> UpdateAsync(int id, TarefaUpdateDto tarefaDto);
        Task DeleteAsync(int id);
        //Task<bool> UpdateAsync(TarefaUpdateDto tarefaDto);
    }
}