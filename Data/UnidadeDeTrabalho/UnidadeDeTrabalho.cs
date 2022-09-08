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

        public void AbrirTransacao() => this.dbContextTransaction_ = this.contexto_.Database.BeginTransaction();

        public void CommitTransacao()
        {
            if (this.dbContextTransaction_ != null)
                this.dbContextTransaction_.Commit();
        }

        public void Dispose()
        {
            if (this.contexto_ != null)
                this.contexto_.Dispose();

            if (this.dbContextTransaction_ != null)
                this.dbContextTransaction_.Dispose();
        }

        public void RollBackTransacao()
        {
            if (this.dbContextTransaction_ != null)
                this.dbContextTransaction_.Rollback();
        }
    }
}
