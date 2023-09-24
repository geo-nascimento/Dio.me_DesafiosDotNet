using GerenciadorTarefas.Enums;

namespace GerenciadorTarefas.Models;

public class Tarefa
{
    public int TarefaId { get; set; }
    public string? Titulo { get; set; }
    public string? Descricao { get; set; }
    public DateTime DtaCriacao { get; set; }
    public Status Status { get; set; }
}
