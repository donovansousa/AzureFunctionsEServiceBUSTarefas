using Data.Mapeamentos;
using Dominio.Agregados.TarefasAgregado;
using Microsoft.EntityFrameworkCore;

namespace Data.ContextoDB
{
    public class Contexto : DbContext
    {
        public virtual DbSet<Tarefas> Tarefas { get; set; }

        public Contexto(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeamentos
            modelBuilder.ApplyConfiguration(new TarefasMapeamento());

            base.OnModelCreating(modelBuilder);
        }
    }
}
