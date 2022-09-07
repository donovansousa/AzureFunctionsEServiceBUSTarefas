using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Commands.InsereTarefa
{
    public class InsereTarefaHandler : IRequestHandler<InsereTarefaCommand, IActionResult>
    {
        public Task<IActionResult> Handle(InsereTarefaCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
