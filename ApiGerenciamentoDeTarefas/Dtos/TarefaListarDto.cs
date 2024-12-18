namespace ApiGerenciamentoDeTarefas.Dtos;

public class TarefaListarDto
{
    public int Id { get; set; }
    
    public string Nome{ get; set; }
    
    public string Descricao { get; set; }
    
    public DateTime DataCriacao { get; set; }
    
    public TimeSpan HoraCriacao { get; set; }
}