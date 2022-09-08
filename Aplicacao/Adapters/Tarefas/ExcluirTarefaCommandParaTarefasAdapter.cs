using Aplicacao.Commands.ExcluiTarefa;
using DominioTarefas = Dominio.Agregados.TarefasAgregado;

namespace Aplicacao.Adapters
{
    public class ExcluirTarefaCommandParaTarefasAdapter : IAdapt<ExcluiTarefaCommand, DominioTarefas.Tarefas>
    {
        public DominioTarefas.Tarefas Adapt(ExcluiTarefaCommand entity)
        {
            return new DominioTarefas.Tarefas()
            {
                Id = entity.Id,
            };
        }
    }
}