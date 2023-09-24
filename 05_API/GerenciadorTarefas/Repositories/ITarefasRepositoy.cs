using GerenciadorTarefas.Enums;
using GerenciadorTarefas.Models;

namespace GerenciadorTarefas.Repositories;

public interface ITarefasRepositoy
{
    //Gets
    public Task<IEnumerable<Tarefa>> GetAllAsync();
    public Task<Tarefa> GetTarefaByIdAsync(int id);
    public Task<Tarefa> GetTarefaByTitleAsync(string title);
    public Task<Tarefa> GetTarefaByDateAsync(DateTime date);
    public Task<IEnumerable<Tarefa>> GetTarefaByStatusAsync(Status status);

    //Post
    public void PostTarefa(Tarefa tarefa);

    //Put
    public void PutTarefa(Tarefa tarefa);

    //Delete
    public void DeleteTarefa(Tarefa tarefa);

    //Auxiliar
    public Tarefa GetTarefaById(int id);
}
