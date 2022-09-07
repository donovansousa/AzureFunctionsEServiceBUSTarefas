using Data.Repositorios;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.UnidadeDeTrabalho;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Data.UnidadeDeTrabalho
{
    public class UnidadeDeTrabalho : IUnidadeDeTrabalho
    {
        private DbContext contexto_ = null!;
        private IDbContextTransaction dbContextTransaction_ = null!;

        public ITarefasRepositorio TarefasRepositorio { get; set; } = null!;

        public UnidadeDeTrabalho(DbContext contexto)
        {
            this.contexto_ = contexto;
            this.TarefasRepositorio = new TarefasRepositorio(contexto);
        }

        public async void AbrirTransacao() => this.dbContextTransaction_ = await this.contexto_.Database.BeginTransactionAsync();

        public async void CommitTransacao()
        {
            if (this.dbContextTransaction_ != null)
                await this.dbContextTransaction_.CommitAsync();
        }

        public void Dispose()
        {
            if (this.contexto_ != null)
                this.contexto_.Dispose();

            if (this.dbContextTransaction_ != null)
                this.dbContextTransaction_.Dispose();
        }

        public async void RollBackTransacao()
        {
            if (this.dbContextTransaction_ != null)
                await this.dbContextTransaction_.RollbackAsync();
        }
    }
}
