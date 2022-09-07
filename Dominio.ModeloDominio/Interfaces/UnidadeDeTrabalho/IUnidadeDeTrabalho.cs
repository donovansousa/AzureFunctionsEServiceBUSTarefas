using Dominio.Interfaces.Repositorios;

namespace Dominio.Interfaces.UnidadeDeTrabalho
{
    public interface IUnidadeDeTrabalho
    {
        ITarefasRepositorio TarefasRepositorio { get; set; }

        void AbrirTransacao();
        void CommitTransacao();
        void RollBackTransacao();
        void Dispose();
    }
}
