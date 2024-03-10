using BancoDadosTest.Application.CustonException;
using Newtonsoft.Json;
using System.Net;

namespace GerenciadorTurmas.Api.Common.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception is RegraNegocioException regraNegocioException)
            {
                var response = new { message = regraNegocioException.Message };
                var jsonResponse = JsonConvert.SerializeObject(response);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                return context.Response.WriteAsync(jsonResponse);
            }
            else
            {
                var response = new { message = "Ocorreu um erro durante o processamento da solicitação. Caso o erro persista, entre em contato com o suporte." };
                var jsonResponse = JsonConvert.SerializeObject(response);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                return context.Response.WriteAsync(jsonResponse);
            }
        }
    }

    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}





