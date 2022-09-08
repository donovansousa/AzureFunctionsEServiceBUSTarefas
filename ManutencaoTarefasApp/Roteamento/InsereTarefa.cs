using Aplicacao.Commands.InsereTarefa;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace ManutencaoTarefasApp.Roteamento
{
    public class InsereTarefa
    {
        private IMediator mediator_;

        public InsereTarefa(IMediator mediator) => this.mediator_ = mediator;


        [FunctionName("InserirTarefa")]
        public async Task<IActionResult> InserirTarefa([HttpTrigger(authLevel: AuthorizationLevel.Anonymous,
                                                        methods: "POST",
                                                        Route = "tarefas")]
                                            HttpRequest request)
        {
            InsereTarefaCommand tarefa = JsonConvert.DeserializeObject<InsereTarefaCommand>(
                                                            new StreamReader(request.Body).ReadToEnd());

            return await this.mediator_.Send(tarefa);
        }
    }
}
