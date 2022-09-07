using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapeamentos
{
    public abstract class BaseMapeamento<T> : IEntityTypeConfiguration<T>
        where T : class
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            CriarTabela(builder);
            CriarColunas(builder);
            CriarChavePrimaria(builder);
            CriarChavesEstrangeiras(builder);
        }

        protected abstract void CriarTabela(EntityTypeBuilder<T> builder);
        protected abstract void CriarColunas(EntityTypeBuilder<T> builder);
        protected abstract void CriarChavePrimaria(EntityTypeBuilder<T> builder);
        protected abstract void CriarChavesEstrangeiras(EntityTypeBuilder<T> builder);
    }
}
