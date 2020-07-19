using HomeBudgetCalculator.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace HomeBudgetCalculator.API.Middleware
{
    public class ExceptionMiddlewareHandler
    {
        private readonly RequestDelegate _request;

        public ExceptionMiddlewareHandler(RequestDelegate request)
        {
            _request = request;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _request(context);
            }
            catch(Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        public static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var errorCode = "Error";
            var exceptionType = exception.GetType();
            HttpStatusCode statusCode;
            switch (exception)
            {
                case Exception e when exceptionType == typeof(UnauthorizedAccessException):
                    statusCode = HttpStatusCode.Unauthorized;
                    break;

                case ServiceExceptions e when exceptionType == typeof(ServiceExceptions):
                    statusCode = HttpStatusCode.BadRequest;
                    errorCode = e.Code;
                    break;

                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            var response = new { code = errorCode, message = exception.Message };
            var payload = JsonConvert.SerializeObject(response);
            context.Response.ContentType = "applicaton/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(payload);
        }
    }
}
