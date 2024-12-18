using ApiGerenciamentoDeTarefas.Configuration;
using Microsoft.EntityFrameworkCore;
using ApiGerenciamentoDeTarefas.Models;


namespace ApiGerenciamentoDeTarefas.Repository
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly AppDbContext _context;

        public TarefaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tarefa>> GetAllAsync() => await _context.Tarefas.ToListAsync();

        public async Task<Tarefa> GetByIdAsync(int id) => await _context.Tarefas.FindAsync(id);

        public async Task AddAsync(Tarefa tarefa)
        {
            await _context.Tarefas.AddAsync(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
            int linhasAfetadas = await _context.SaveChangesAsync();

            if (linhasAfetadas > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
            
        }

        public async Task DeleteAsync(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa != null)
            {
                _context.Tarefas.Remove(tarefa);
                await _context.SaveChangesAsync();
            }
        }
    }
}