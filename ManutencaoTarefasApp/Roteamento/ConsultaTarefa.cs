using Aplicacao.Queries.Tarefas.ConsultaTarefa;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System.Threading.Tasks;

namespace ManutencaoTarefasApp.Roteamento
{
    public class ConsultaTarefa
    {
        private IMediator mediator_;
        public ConsultaTarefa(IMediator mediator) => this.mediator_ = mediator;

        [FunctionName("ConsultarTarefa")]
        public async Task<IActionResult> ConsultarTarefa([HttpTrigger(authLevel: AuthorizationLevel.Anonymous,
                                                 methods: "GET",
                                                 Route = "{titulo}/tarefas")]
                                     HttpRequest request)
        {
            return await this.mediator_.Send(new ConsultaTarefaQuery() { Titulo = request.RouteValues["titulo"].ToString() });
        }
    }
}
