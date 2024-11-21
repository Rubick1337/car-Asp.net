using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Car_oop.Models.Exception_custom;

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
                // Передаем запрос дальше по конвейеру
                await _next(context);
            }
            catch (Exception ex)
            {
                // Логика обработки исключений
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Проверяем наличие контекста исключения
            var contextFeature = new { Error = exception };

            if (contextFeature != null)
            {
                // Устанавливаем статус код на основе типа исключения
                context.Response.StatusCode = contextFeature.Error switch
                {
                    NotFound => StatusCodes.Status404NotFound,
                    BadRequestException => StatusCodes.Status400BadRequest,

                    _ => StatusCodes.Status500InternalServerError
                };

                // Устанавливаем Content-Type для ответа
                context.Response.ContentType = "application/json";

                // Создаем объект ошибки
                var errorDetails = new ErrorDetails
                {
                    StatusCode = context.Response.StatusCode,
                    Message = contextFeature.Error.Message
                };

                // Пишем объект ошибки в ответ в формате JSON
                await context.Response.WriteAsync(JsonConvert.SerializeObject(errorDetails));
            }
        }

        // Класс для представления деталей ошибки
        public class ErrorDetails
        {
            public int StatusCode { get; set; }
            public string Message { get; set; }
        }
    }
}
