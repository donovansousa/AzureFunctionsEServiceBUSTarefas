using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace ManutencaoTarefasApp.Roteamento
{
    public class InsereTarefa
    {
        [FunctionName("InserirTarefa")]
        public void InserirTarefa([HttpTrigger(authLevel: AuthorizationLevel.Anonymous,
                                               methods: "POST",
                                               Route = "")] 
                                   HttpRequest request)
        {
        }
    }
}
