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
        public DbSet<Colaborador> Colaborador { get; set; }

        /* Configuração do relacionamento entre Colaborador e Tarefa */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
             HasMany  - Um colaborador pode ter várias tarefas.
             WithOne  - Uma tarefa pertence a um colaborador.   
             HasForeignKey - Relacionando a Chave estrageira ColaboradorId na tabela Tarefa   
                    
            */
            modelBuilder.Entity<Colaborador>()
                 .HasMany(c => c.Tarefas)
                 .WithOne(t => t.Colaborador)
                 .HasForeignKey(t => t.ColaboradorId);
               base.OnModelCreating(modelBuilder);
        }


        /* Método para obter todos os colaboradores */
        public async Task<ICollection<Colaborador>> BuscarTodosColaboradores()
        {
            return await Colaborador.ToListAsync();
        }

        /* Método para obter todos os colaboradores */
        public async Task<ICollection<Tarefa>> BuscarTodasTarefas()
        {
            return await Tarefas.ToListAsync();
        }

        /* Método para obter Colaborador por Nome */
        public async Task<Colaborador> GetColaboradorPorNome(string nome)
        {
            return await Colaborador.FirstOrDefaultAsync(c => c.Nome == nome);
        }
    }

}


