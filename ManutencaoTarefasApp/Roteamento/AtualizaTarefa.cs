using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace ManutencaoTarefasApp.Roteamento
{
    public class AtualizaTarefa
    {
        [FunctionName("AtualizarTarefa")]
        public void AtualizarTarefa([HttpTrigger(authLevel: AuthorizationLevel.Anonymous,
                                                 methods: "PATCH",
                                                 Route = "{id}/{titulo}/{descricao}/tarefas")]
                                     HttpRequest request)
        {
        }
    }
}
