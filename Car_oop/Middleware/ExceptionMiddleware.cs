using Car_oop.Models.Exception_custom;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Car_oop.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
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

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            context.Response.StatusCode = exception switch
            {
                NotFound _ => StatusCodes.Status404NotFound,
                BadRequestException _ => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

            var errorDetails = new ErrorDetails
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            };

            await context.Response.WriteAsync($"{{\"StatusCode\": {errorDetails.StatusCode}, \"Message\": \"{errorDetails.Message}\"}}");
        }

        public class ErrorDetails
        {
            public int StatusCode { get; set; }
            public string Message { get; set; }
        }
    }
}
