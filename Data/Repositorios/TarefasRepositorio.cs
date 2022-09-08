using Dominio.Agregados.TarefasAgregado;
using Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositorios
{
    public class TarefasRepositorio : BaseRepositorio<Tarefas>, ITarefasRepositorio
    {
        public TarefasRepositorio(DbContext context) : base(context)
        {
        }

        public bool DescricaoDaTarefaJaExiste(string descricao) => this.context
                .Set<Tarefas>().Any(t => t.Descricao.Equals(descricao));

        public IEnumerable<Tarefas> ListarTarefasPeloTitulo(string titulo) => this.context.Set<Tarefas>()
                        .Where(t => t.Titulo.Contains(titulo))
                        .Select(t => t).AsEnumerable();

        public bool TituloDaTarefaJaExiste(string titulo) => this.context
                .Set<Tarefas>().Any(t => t.Titulo.Equals(titulo));

    }
}
