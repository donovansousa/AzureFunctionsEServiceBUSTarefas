using Aplicacao.Adapters.Tarefas;
using Aplicacao.Commands;
using Aplicacao.DTO;
using Data.UnidadeDeTrabalho;
using Dominio.Interfaces.UnidadeDeTrabalho;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using DominioTarefas = Dominio.Agregados.TarefasAgregado;

namespace Aplicacao.Queries.Tarefas.ConsultaTarefa
{
    public class ConsultaTarefaHandler : BaseHandler, IRequestHandler<ConsultaTarefaQuery, IActionResult>
    {
        private readonly IUnidadeDeTrabalho unidadeDeTrabalho;

        public ConsultaTarefaHandler(IUnidadeDeTrabalho unidadeDeTrabalho) => this.unidadeDeTrabalho = unidadeDeTrabalho;

        public async Task<IActionResult> Handle(ConsultaTarefaQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<DominioTarefas.Tarefas> tarefas = this.unidadeDeTrabalho.TarefasRepositorio.ListarTarefasPeloTitulo(request.Titulo).ToList();

                if (tarefas.Count == 0)
                {
                    return await this.ResponderApenasComStatusCode(System.Net.HttpStatusCode.NotFound);
                }

                List<ListaTarefaDTO> listagemDeTarefas = new TarefasParaListaTarefaDTOAdapt().Adapt(tarefas);

                return await Task.FromResult(new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.OK,
                    ContentType = System.Net.Mime.MediaTypeNames.Application.Json,
                    Content = JsonConvert.SerializeObject(listagemDeTarefas),
                });
            }
            catch (Exception ex)
            {
                return this.RetornarErro(ex);
            }
            finally
            {
                this.unidadeDeTrabalho.Dispose();
            }
        }
    }
}
