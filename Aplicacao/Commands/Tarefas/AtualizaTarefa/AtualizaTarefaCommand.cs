using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacao.Commands.Tarefas.AtualizaTarefa
{
    public class AtualizaTarefaCommand: IRequest<IActionResult>
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }
}
