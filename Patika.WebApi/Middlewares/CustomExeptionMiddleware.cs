using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;
using Patika.WebApi.Services;

namespace Patika.WebApi.Middlewares
{
    public class CustomExeptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;
        public CustomExeptionMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }
        public async Task Invoke(HttpContext context)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            try
            {
                string message = "[Request] HTTP " + context.Request.Method + " - " + context.Request.Path;
                Console.WriteLine(message);
                await _next(context);
                watch.Stop();
                message = "[Response] HTTP " + context.Request.Method + " - " + context.Request.Path + " responded " + context.Response.StatusCode + " in " + watch.ElapsedMilliseconds + " ms";
                _loggerService.Write(message);
            }
            catch (Exception ex)
            {
                watch.Stop();
                await HandleExceptionAsync(context, ex, watch);
            }


        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex, System.Diagnostics.Stopwatch watch)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "[Error] HTTP " + context.Request.Method + " - " + context.Response.StatusCode + " Error Message " + ex.Message + " in " + watch.ElapsedMilliseconds + " ms";
            _loggerService.Write(message);


            var result = JsonConvert.SerializeObject(new { error = ex.Message }, Formatting.None);
            return context.Response.WriteAsync(result);
        }

    }

    public static class CustomExeptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExeptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExeptionMiddleware>();
        }
    }
    internal class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }


}