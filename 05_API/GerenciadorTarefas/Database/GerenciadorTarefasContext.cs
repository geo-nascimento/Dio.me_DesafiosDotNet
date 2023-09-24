using GerenciadorTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTarefas.Database;

public class GerenciadorTarefasContext : DbContext
{
    public GerenciadorTarefasContext(DbContextOptions<GerenciadorTarefasContext> options) : base(options)
    {

    }

    public DbSet<Tarefa>? Tarefas { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<Tarefa>().HasKey(t => t.TarefaId);
        mb.Entity<Tarefa>().Property(t => t.Titulo).HasMaxLength(100).IsRequired();
        mb.Entity<Tarefa>().Property(t => t.Descricao).HasMaxLength(500).IsRequired();
        mb.Entity<Tarefa>().Property(t => t.Status).HasConversion<string>();
    }
}
