using Crud.Common.Exceptions;
using Crud.Common.Helpers;
using Crud.Models.GlobalModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud.Api.Infrastructure.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int statusCode = context.Response.StatusCode;

            try
            {
                if (exception != null && exception is HttpException)
                {
                    statusCode = (exception as HttpException).StatusCode;
                }
                else
                {
                    if (exception != null)
                    {
                        statusCode = 500;
                    }
                }

                var logger = context.RequestServices.GetService(typeof(Logger));
                if (statusCode == 500)
                {
                    ((Logger)logger).Log(LogType.Error);
                }

            }
            finally
            {
                context.Response.Clear();
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsync(exception.Message);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
