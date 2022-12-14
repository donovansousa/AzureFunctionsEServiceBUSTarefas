using Data.UnidadeDeTrabalho;
using Dominio.Interfaces.UnidadeDeTrabalho;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DominioTarefas = Dominio.Agregados.TarefasAgregado;
using System.Net;
using Aplicacao.Adapters;

namespace Aplicacao.Commands.ExcluiTarefa
{
    public class ExcluiTarefaHandler : BaseHandler, IRequestHandler<ExcluiTarefaCommand, IActionResult>
    {
        private readonly IUnidadeDeTrabalho unidadeDeTrabalho;

        public ExcluiTarefaHandler(IUnidadeDeTrabalho unidadeDeTrabalho) => this.unidadeDeTrabalho = unidadeDeTrabalho;

        public async Task<IActionResult> Handle(ExcluiTarefaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this.unidadeDeTrabalho.AbrirTransacao();

                DominioTarefas.Tarefas tarefa = new ExcluirTarefaCommandParaTarefasAdapter().Adapt(request);
                this.unidadeDeTrabalho.TarefasRepositorio.Excluir(tarefa);

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
