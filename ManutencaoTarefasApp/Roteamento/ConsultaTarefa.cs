using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace ManutencaoTarefasApp.Roteamento
{
    public class ConsultaTarefa
    {
        [FunctionName("ConsultarTarefa")]
        public void ConsultarTarefa([HttpTrigger(authLevel: AuthorizationLevel.Anonymous,
                                                 methods: "GET",
                                                 Route = "{id}/tarefas")]
                                     HttpRequest request)
        {
        }
    }
}
