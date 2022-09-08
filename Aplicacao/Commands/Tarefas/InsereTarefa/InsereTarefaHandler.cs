using Aplicacao.Adapters.Tarefas;
using Data.UnidadeDeTrabalho;
using Dominio.Interfaces.UnidadeDeTrabalho;
using MediatR;
using DominioTarefas = Dominio.Agregados.TarefasAgregado;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Aplicacao.DTO;

namespace Aplicacao.Commands.InsereTarefa
{
    public class InsereTarefaHandler : BaseHandler, IRequestHandler<InsereTarefaCommand, IActionResult>
    {
        private readonly IUnidadeDeTrabalho unidadeDeTrabalho;

        public InsereTarefaHandler(UnidadeDeTrabalho unidadeDeTrabalho) => this.unidadeDeTrabalho = unidadeDeTrabalho;

        public async Task<IActionResult> Handle(InsereTarefaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                this.unidadeDeTrabalho.AbrirTransacao();

                DominioTarefas.Tarefas tarefa = new InsereTarefaCommandParaTarefasAdapter().Adapt(request);
                this.unidadeDeTrabalho.TarefasRepositorio.Adicionar(tarefa);

                this.unidadeDeTrabalho.CommitTransacao();

                InsereTarefaRespostaDTO insereTarefaResposta = new TarefasParaInsereTarefaRespostaDTOAdapt().Adapt(tarefa);

                return await this.ResponderStatusCodeCreated<InsereTarefaRespostaDTO>(insereTarefaResposta);
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
