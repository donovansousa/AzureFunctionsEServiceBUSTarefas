using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Commands.ExcluiTarefa
{
    public class ExcluiTarefaCommand : IRequest<IActionResult>
    {
        public int Id { get; set; }
    }
}
