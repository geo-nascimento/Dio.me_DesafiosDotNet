using GerenciadorTarefas.Database;
using GerenciadorTarefas.Enums;
using GerenciadorTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTarefas.Repositories;

public class TarefasRepository : ITarefasRepositoy
{
    private readonly GerenciadorTarefasContext _db;
    public TarefasRepository(GerenciadorTarefasContext db)
    {
        _db = db;
    }
    public async Task<IEnumerable<Tarefa>> GetAllAsync()
    {
        var tarefas = await _db.Tarefas!.ToListAsync();

        return tarefas;
    }

    public async Task<Tarefa> GetTarefaByIdAsync(int id)
    {
        var tarefa = await _db.Tarefas!.FirstOrDefaultAsync(t => t.TarefaId == id);

        if (tarefa is null)
        {
            throw new ArgumentNullException("Tarefa não encontrada");
        }

        return tarefa;
    }

    public Tarefa GetTarefaById(int id)
    {
        var tarefa = _db.Tarefas!.FirstOrDefault(t => t.TarefaId == id);

        if (tarefa is null)
        {
            throw new ArgumentNullException("Tarefa não encontrada");
        }

        return tarefa;

    }

    public async Task<Tarefa> GetTarefaByDateAsync(DateTime date)
    {
        var tarefa = await _db.Tarefas!.FirstOrDefaultAsync(t => t.DtaCriacao == date);

        if (tarefa is null)
        {
            throw new ArgumentNullException("Tarefa não encontrada");
        }

        return tarefa;
    }

    public async Task<IEnumerable<Tarefa>> GetTarefaByStatusAsync(Status status)
    {
        var tarefas = await _db.Tarefas!.Where(t => t.Status == status).ToListAsync();

        if (tarefas is null)
        {
            throw new ArgumentNullException("Tarefa não encontrada");
        }

        return tarefas;
    }

    public async Task<Tarefa> GetTarefaByTitleAsync(string title)
    {
        var tarefa = await _db.Tarefas!.FirstOrDefaultAsync(t => t.Titulo!.Contains(title));

        if (tarefa is null)
        {
            throw new ArgumentNullException("Tarefa não encontrada");
        }

        return tarefa;
    }

    public void PostTarefa(Tarefa tarefa)
    {
        if (tarefa is null)
        {
            throw new ArgumentNullException("A entrada precisa ter dados válidos");
        }

        _db.Tarefas!.Add(tarefa);
        _db.SaveChanges();
    }

    public void PutTarefa(Tarefa tarefa)
    {

        if (tarefa is null)
        {
            throw new ArgumentNullException("A entrada precisa ter dados válidos");
        }

        _db.Update(tarefa);
        _db.SaveChanges();
    }

    public void DeleteTarefa(Tarefa tarefa)
    {
        if (tarefa is null)
        {
            throw new ArgumentNullException("A entrada precisa ter dados válidos");
        }
        _db.Tarefas!.Remove(tarefa);
        _db.SaveChanges();
    }

}
