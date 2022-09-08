using Aplicacao.DTO;
using DominioTarefas = Dominio.Agregados.TarefasAgregado;

namespace Aplicacao.Adapters.Tarefas
{
    public class TarefasParaInsereTarefaRespostaDTOAdapt : IAdapt<DominioTarefas.Tarefas, InsereTarefaRespostaDTO>
    {
        public InsereTarefaRespostaDTO Adapt(DominioTarefas.Tarefas tarefa)
        {
            return new InsereTarefaRespostaDTO()
            {
                Id = tarefa.Id,
                Descricao = tarefa.Descricao,
                Titulo = tarefa.Titulo
            };
        }
    }
}
