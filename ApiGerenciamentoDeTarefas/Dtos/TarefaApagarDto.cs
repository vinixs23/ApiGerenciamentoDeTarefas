namespace ApiGerenciamentoDeTarefas.Dtos;

public class TarefaApagarDto
{
    public int Id { get; set; }
    
    public string Nome{ get; set; }
    
    public string Descricao { get; set; }
    
    public DateTime DataCriacao { get; set; }
    
    public TimeSpan HoraCriacao { get; set; }
}