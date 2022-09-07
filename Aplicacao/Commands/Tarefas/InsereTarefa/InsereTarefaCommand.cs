using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Commands.InsereTarefa
{
    public class InsereTarefaCommand : IRequest<IActionResult>
    {
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }
}
