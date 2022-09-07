using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Queries.Tarefas.ConsultaTarefa
{
    public class ConsultaTarefaQuery: IRequest<IActionResult>
    {
        public string Titulo { get; set; } = string.Empty;
    }
}
