
using Dominio.Agregados.TarefasAgregado;

namespace Dominio.Interfaces.Repositorios
{
    public interface ITarefasRepositorio: IBaseRepositorio<Tarefas>
    {
        IEnumerable<Tarefas> ListarTarefasPeloTitulo(string titulo);
        bool TituloDaTarefaJaExiste(string titulo);
        bool DescricaoDaTarefaJaExiste(string descricao);
        bool IdDaTarefaExiste(int id);
     }
}
