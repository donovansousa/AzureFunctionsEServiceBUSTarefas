
using Dominio.Agregados.TarefasAgregado;

namespace Dominio.Interfaces.Repositorios
{
    public interface ITarefasRepositorio: IBaseRepositorio<Tarefas>
    {
        IEnumerable<Tarefas> ListarTarefasPeloTitulo(string titulo);
        Task<Tarefas> ListarTarefaPeloId(int id);
        IEnumerable<Tarefas> ListarTarefaPelaDescricao(string descricao);
     }
}
