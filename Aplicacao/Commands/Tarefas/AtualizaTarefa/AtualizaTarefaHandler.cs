using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Commands.Tarefas.AtualizaTarefa
{
    public class AtualizaTarefaHandler : IRequestHandler<AtualizaTarefaCommand, IActionResult>
    {
        public Task<IActionResult> Handle(AtualizaTarefaCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
