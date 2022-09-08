using Aplicacao.Commands.InsereTarefa;
using DominioTarefas = Dominio.Agregados.TarefasAgregado;

namespace Aplicacao.Adapters.Tarefas
{
    public class InsereTarefaCommandParaTarefasAdapter : IAdapt<InsereTarefaCommand, DominioTarefas.Tarefas>
    {
        public DominioTarefas.Tarefas Adapt(InsereTarefaCommand entity)
        {
            return new DominioTarefas.Tarefas()
            {
                Descricao = entity.Descricao,
                Titulo = entity.Titulo
            };
        }
    }
}
