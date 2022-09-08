using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace ManutencaoTarefasApp.Processadores
{
    public class ProcessaTarefa
    {
        [FunctionName("ProcessarTarefa")]
        public void Run([ServiceBusTrigger("fila-de-processo", Connection = "conexaoServiceBUS")] string myQueueItem, 
                        ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
