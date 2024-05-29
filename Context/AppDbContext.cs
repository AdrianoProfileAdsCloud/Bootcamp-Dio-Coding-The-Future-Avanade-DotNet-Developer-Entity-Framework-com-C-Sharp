using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Models;

namespace ProjetoAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Colaborador> Colaborador { get;set;}

         protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarefa>()
            .HasOne(t => t.Colaborador)
            .WithMany(c => c.Tarefas)
            .HasForeignKey(t => t.ColaboradorId);
    }
    }
    
}


