using Aplicacao.Commands.ExcluiTarefa;
using Aplicacao.DTO;
using Azure.Messaging.ServiceBus;
using Dominio.Interfaces.UnidadeDeTrabalho;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ManutencaoTarefasApp.Roteamento
{
    public class ExcluiTarefa
    {
        private IUnidadeDeTrabalho unidadeDeTrabalho_;
        private IConfiguration configuration_;

        public ExcluiTarefa(IUnidadeDeTrabalho unidadeDeTrabalho,
                            IConfiguration configuration)
        {
            this.unidadeDeTrabalho_ = unidadeDeTrabalho;
            this.configuration_ = configuration;
        }

        [FunctionName("ExcluirTarefa")]
        public async Task<IActionResult> ExcluirTarefa([HttpTrigger(authLevel: AuthorizationLevel.Anonymous,
                                               methods: "PATCH",
                                               Route = "{id}/tarefas")]
                                     HttpRequest request)
        {
            try
            {
                int id = Convert.ToInt32(request.RouteValues["id"]);

                if (id == 0)
                {
                    return new ContentResult()
                    {
                        StatusCode = (int)HttpStatusCode.BadRequest,
                        Content = JsonConvert.SerializeObject(new RespostaValidacaoDTO() { Mensagem = "O id da tarefa deve ser informado!" }),
                        ContentType = System.Net.Mime.MediaTypeNames.Application.Json,
                    };
                }

                if (!(this.unidadeDeTrabalho_.TarefasRepositorio.IdDaTarefaExiste(id)))
                {
                    return new ContentResult()
                    {
                        StatusCode = (int)HttpStatusCode.UnprocessableEntity,
                        Content = JsonConvert.SerializeObject(new RespostaValidacaoDTO() { Mensagem = "O id da tarefa não existe!" }),
                        ContentType = System.Net.Mime.MediaTypeNames.Application.Json,
                    };
                }

                ServiceBusClient serviceBusClient = new ServiceBusClient(this.configuration_.GetConnectionString("ExcluiTarefaFila"));
                ServiceBusSender sender = serviceBusClient.CreateSender("exclui-tarefa-fila");

                await sender.SendMessageAsync(new ServiceBusMessage(JsonConvert.SerializeObject(
                     new ExcluiTarefaCommand()
                     {
                         Id = id
                     })));

                // Insere na fila para processamento da exclusão
                return new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.NoContent,
                };
            }
            catch (Exception ex)
            {
                return new ContentResult()
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Content = JsonConvert.SerializeObject(ex),
                    ContentType = System.Net.Mime.MediaTypeNames.Application.Json,
                };
            }
            finally
            {
                this.unidadeDeTrabalho_.Dispose();
            }
        }
    }
}
