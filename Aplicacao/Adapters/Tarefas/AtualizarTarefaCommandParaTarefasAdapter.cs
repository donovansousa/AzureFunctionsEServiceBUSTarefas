using Aplicacao.Commands.Tarefas.AtualizaTarefa;
using DominioTarefas = Dominio.Agregados.TarefasAgregado;

namespace Aplicacao.Adapters
{
    public class AtualizarTarefaCommandParaTarefasAdapter : IAdapt<AtualizaTarefaCommand, DominioTarefas.Tarefas>
    {
        public DominioTarefas.Tarefas Adapt(AtualizaTarefaCommand entity)
        {
            return new DominioTarefas.Tarefas()
            {
                Id = entity.Id,
                Descricao = entity.Descricao,
                Titulo = entity.Titulo
            };
        }
    }
}
