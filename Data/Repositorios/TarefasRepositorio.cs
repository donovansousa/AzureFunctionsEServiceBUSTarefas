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

        public IEnumerable<Tarefas> ListarTarefaPelaDescricao(string descricao) => this.context.Set<Tarefas>()
                        .Where(t => t.Descricao.Contains(descricao))
                        .Select(t => t).AsEnumerable();

        public async Task<Tarefas> ListarTarefaPeloId(int id) => await this.context.Set<Tarefas>()
                        .Where(t => t.Id == id)
                        .Select(t => t).FirstOrDefaultAsync();


        public IEnumerable<Tarefas> ListarTarefasPeloTitulo(string titulo) => this.context.Set<Tarefas>()
                        .Where(t => t.Titulo.Contains(titulo))
                        .Select(t => t).AsEnumerable();
    }
}
