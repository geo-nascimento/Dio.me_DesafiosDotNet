using GerenciadorsDeTarefas.Data;
using GerenciadorsDeTarefas.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorsDeTarefas.Repository
{
    public class TarefaRepository : ITarefasRepository
    {
        //Injeção de Dependência com o banco de dados

        private readonly GerenciadorsDeTarefasContext _context;

        public TarefaRepository(GerenciadorsDeTarefasContext context) 
        {
            _context = context;
        }

        public void CriarTarefa(Tarefa tarefa)
        {
            _context.Tarefa.Add(tarefa);
            _context.SaveChanges();
        }

        public void AtualizarTarefa(Tarefa tarefa)
        {
            _context.Tarefa.Update(tarefa);
            _context.SaveChanges();
        }

        public void DeletarTarefa(int id)
        {
            var result = ObterTarefa(id);
            _context.Tarefa.Remove(result);
            _context.SaveChanges();
        }

        public List<Tarefa> ObterTodas()
        {
            var list = _context.Tarefa.OrderBy(t => t.Id).ToList();
            return list;
        }

        public Tarefa ObterTarefa(int id)
        {
            var tarefa = _context.Tarefa.Find(id);

            return tarefa!;
        }
    }
}
