using InterviewProject.ActionResults;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http;

namespace InterviewProject.Filters
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<HttpGlobalExceptionFilter> _logger;
        public HttpGlobalExceptionFilter(ILogger<HttpGlobalExceptionFilter> logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(HttpRequestException))
            {
                var httpRequestException = context.Exception as HttpRequestException;
                var json = new JsonErrorResponse
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    DeveloperMessage = httpRequestException.Message
                };

                context.Result = new InternalServerErrorObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            else
            {
                var json = new JsonErrorResponse
                {
                    Messages = new[] { "An error ocurred." }
                };

                context.Result = new InternalServerErrorObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            _logger.LogError(context.Exception.Message);
            _logger.LogError(context.Exception.StackTrace);
            context.ExceptionHandled = true;
        }
        private class JsonErrorResponse
        {
            public int StatusCode { get; set; }
            public string[] Messages { get; set; }
            public object DeveloperMessage { get; set; }
        }
    }
}