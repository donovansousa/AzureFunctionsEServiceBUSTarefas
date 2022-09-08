using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace Aplicacao.Commands
{
    public abstract class BaseHandler
    {
        public IActionResult RetornarErro(Exception ex)
        {
            return new ContentResult()
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                ContentType = System.Net.Mime.MediaTypeNames.Application.Json,
                Content = JsonConvert.SerializeObject(ex)
            };
        }

        public async Task<IActionResult> ResponderApenasComStatusCode(HttpStatusCode statusCode)
        {
            return await Task.FromResult(new ContentResult()
            {
                StatusCode = (int)statusCode
            });
        }

        public async Task<IActionResult> ResponderStatusCodeCreated<T>(T dto)
        {
            return await Task.FromResult(new ContentResult()
            {
                StatusCode = (int)HttpStatusCode.Created,
                Content = JsonConvert.SerializeObject(dto),
                ContentType = System.Net.Mime.MediaTypeNames.Application.Json,
            });
        }
    }
}
