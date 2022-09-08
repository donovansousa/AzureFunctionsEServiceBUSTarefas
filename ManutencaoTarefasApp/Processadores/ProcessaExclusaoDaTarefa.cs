using Aplicacao.Commands.ExcluiTarefa;
using MediatR;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ManutencaoTarefasApp.Processadores
{
    public class ProcessaExclusaoDaTarefa
    {
        private IMediator mediator_;
        public ProcessaExclusaoDaTarefa(IMediator mediator) => this.mediator_ = mediator;

        [FunctionName("ProcessarExclusaoDaTarefa")]
        public void Run([ServiceBusTrigger("exclui-tarefa-fila", Connection = "ExcluiTarefaFila")] string myQueueItem,
                        ILogger log)
        {
            ExcluiTarefaCommand excluiTarefaCommand = JsonConvert.DeserializeObject<ExcluiTarefaCommand>(myQueueItem);
            this.mediator_.Send(excluiTarefaCommand);

            log.LogDebug($"Tarefa: {excluiTarefaCommand.Id} removida com sucesso!");
        }
    }
}
