using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Queries.Tarefas.ConsultaTarefa
{
    public class ConsultaTarefaHandler : IRequestHandler<ConsultaTarefaQuery, IActionResult>
    {
        public Task<IActionResult> Handle(ConsultaTarefaQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
