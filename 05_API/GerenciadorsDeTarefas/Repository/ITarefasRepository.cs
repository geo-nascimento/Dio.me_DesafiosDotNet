using GerenciadorsDeTarefas.Models;


namespace GerenciadorsDeTarefas.Repository
{
    public interface ITarefasRepository
    {
        void CriarTarefa(Tarefa tarefa);
        Tarefa ObterTarefa(int id);
        void DeletarTarefa(int id);
        void AtualizarTarefa(Tarefa tarefa);
        List<Tarefa> ObterTodas();
    }
}
