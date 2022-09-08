using Aplicacao.Adapters;
using Data.UnidadeDeTrabalho;
using Dominio.Interfaces.UnidadeDeTrabalho;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using DominioTarefas = Dominio.Agregados.TarefasAgregado;

namespace Aplicacao.Commands.Tarefas.AtualizaTarefa
{
    public class AtualizaTarefaHandler : BaseHandler, IRequestHandler<AtualizaTarefaCommand, IActionResult>
    {
        private readonly IUnidadeDeTrabalho unidadeDeTrabalho;

        public AtualizaTarefaHandler(UnidadeDeTrabalho unidadeDeTrabalho) => this.unidadeDeTrabalho = unidadeDeTrabalho;

        public async Task<IActionResult> Handle(AtualizaTarefaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this.unidadeDeTrabalho.AbrirTransacao();

                DominioTarefas.Tarefas tarefa = new AtualizarTarefaCommandParaTarefasAdapter().Adapt(request);
                this.unidadeDeTrabalho.TarefasRepositorio.Atualizar(tarefa);

                this.unidadeDeTrabalho.CommitTransacao();

                return await this.ResponderApenasComStatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                this.unidadeDeTrabalho.RollBackTransacao();
                return this.RetornarErro(ex);
            }
            finally
            {
                this.unidadeDeTrabalho.Dispose();
            }
        }
    }
}
