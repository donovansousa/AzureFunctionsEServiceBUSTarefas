using Aplicacao.DTO;
using DominioTarefas = Dominio.Agregados.TarefasAgregado;

namespace Aplicacao.Adapters.Tarefas
{
    public class TarefasParaListaTarefaDTOAdapt : IAdapt<List<DominioTarefas.Tarefas>, List<ListaTarefaDTO>>
    {
        public List<ListaTarefaDTO> Adapt(List<DominioTarefas.Tarefas> entity)
        {
            List<ListaTarefaDTO> tarefas = new List<ListaTarefaDTO>();

            entity.ForEach(t =>
            {
                tarefas.Add(new ListaTarefaDTO()
                {
                    Id = t.Id,
                    Titulo = t.Titulo,
                    Descricao = t.Descricao
                });
            });

            return tarefas;
        }
    }
}
