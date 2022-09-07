using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace ManutencaoTarefasApp.Roteamento
{
    public class ExcluiTarefa
    {

        [FunctionName("ExcluirTarefa")]
        public void ExcluirTarefa([HttpTrigger(authLevel: AuthorizationLevel.Anonymous,
                                               methods: "PATCH",
                                               Route = "{id}/tarefas")]
                                     HttpRequest request)
        {
        }
    }
}
