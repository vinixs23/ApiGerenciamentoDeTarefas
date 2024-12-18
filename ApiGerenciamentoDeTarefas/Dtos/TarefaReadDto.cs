using System;

namespace ApiGerenciamentoDeTarefas
{
    public class TarefaReadDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public TimeSpan HoraCriacao { get; set; }
    }
}