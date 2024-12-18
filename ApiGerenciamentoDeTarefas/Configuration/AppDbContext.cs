using ApiGerenciamentoDeTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiGerenciamentoDeTarefas.Configuration
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}