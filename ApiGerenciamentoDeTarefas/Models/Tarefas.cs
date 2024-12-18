using System.ComponentModel.DataAnnotations;

namespace ApiGerenciamentoDeTarefas.Models
{
    public class Tarefa
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime DataCriacao { get; set; }

        public TimeSpan HoraCriacao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public TimeSpan? HoraAlteracao { get; set; }
    }
}