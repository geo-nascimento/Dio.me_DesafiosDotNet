namespace GerenciadorTarefas;

public class TarefaDTO
{
    public int TarefaId { get; set; }
    public string? Titulo { get; set; }
    public string? Descricao { get; set; }
    public DateTime DtaCriacao { get; set; }
    public string? Status { get; set; }
}
