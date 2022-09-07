using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Commands.ExcluiTarefa
{
    public class ExcluiTarefaHandler : IRequestHandler<ExcluiTarefaCommand, IActionResult>
    {
        public Task<IActionResult> Handle(ExcluiTarefaCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
