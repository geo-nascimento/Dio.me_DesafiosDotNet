using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GerenciadorsDeTarefas.Models;

namespace GerenciadorsDeTarefas.Data
{
    public class GerenciadorsDeTarefasContext : DbContext
    {
        public GerenciadorsDeTarefasContext (DbContextOptions<GerenciadorsDeTarefasContext> options)
            : base(options)
        {
        }

        public DbSet<Tarefa> Tarefa { get; set; } = default!;
    }
}
