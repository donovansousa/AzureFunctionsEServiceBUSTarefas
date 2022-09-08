using Aplicacao.Adapters.Tarefas;
using Data.UnidadeDeTrabalho;
using Dominio.Interfaces.UnidadeDeTrabalho;
using MediatR;
using DominioTarefas = Dominio.Agregados.TarefasAgregado;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Aplicacao.DTO;
using Newtonsoft.Json;

namespace Aplicacao.Commands.InsereTarefa
{
    public class InsereTarefaHandler : BaseHandler, IRequestHandler<InsereTarefaCommand, IActionResult>
    {
        private readonly IUnidadeDeTrabalho unidadeDeTrabalho;

        public InsereTarefaHandler(IUnidadeDeTrabalho unidadeDeTrabalho) => this.unidadeDeTrabalho = unidadeDeTrabalho;

        public async Task<IActionResult> Handle(InsereTarefaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                List<string> erros = new List<string>();

                if (string.IsNullOrEmpty(request.Titulo))
                {
                    erros.Add("O titulo da tarefa deve ser informado!");
                }

                if (string.IsNullOrEmpty(request.Descricao))
                {
                    erros.Add("A descrição da tarefa deve ser informada!");
                }

                if (erros.Count > 0)
                {
                    return new ContentResult()
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                        Content = JsonConvert.SerializeObject(erros),
                        ContentType = System.Net.Mime.MediaTypeNames.Application.Json,
                    };
                }

                if (this.unidadeDeTrabalho.TarefasRepositorio.TituloDaTarefaJaExiste(request.Titulo))
                {
                    erros.Add("O titulo da tarefa já está sendo utilizado!");
                }

                if (this.unidadeDeTrabalho.TarefasRepositorio.DescricaoDaTarefaJaExiste(request.Descricao))
                {
                    erros.Add("A descrição da tarefa já está sendo utilizada!");
                }

                if (erros.Count > 0)
                {
                    return new ContentResult()
                    {
                        StatusCode = (int)HttpStatusCode.UnprocessableEntity,
                        Content = JsonConvert.SerializeObject(erros),
                        ContentType = System.Net.Mime.MediaTypeNames.Application.Json,
                    };
                }

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
