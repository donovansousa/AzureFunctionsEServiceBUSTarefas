using Dominio.Agregados.TarefasAgregado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapeamentos
{
    public class TarefasMapeamento : BaseMapeamento<Tarefas>
    {
        protected override void CriarChavePrimaria(EntityTypeBuilder<Tarefas> builder) => builder.HasKey(p => p.Id);

        protected override void CriarChavesEstrangeiras(EntityTypeBuilder<Tarefas> builder)
        {
        }

        protected override void CriarColunas(EntityTypeBuilder<Tarefas> builder)
        {
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Titulo).HasColumnName("titulo").HasMaxLength(100).IsUnicode();
            builder.Property(p => p.Descricao).HasColumnName("descricao").HasMaxLength(1000).IsUnicode();
        }

        protected override void CriarTabela(EntityTypeBuilder<Tarefas> builder) => builder.ToTable("tarefas");
    }
}
