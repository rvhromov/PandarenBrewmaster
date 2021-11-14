using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using User.API.Models.Exceptions;

namespace User.API.Filters
{
    public sealed class ExceptionFilter : IExceptionFilter
    {
        public async void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;

            var response = new ErrorResponseModel
            {
                Message = context.Exception.Message
            };
            
            context.HttpContext.Response.Headers.Add(
                new KeyValuePair<string, StringValues>("Content-Type", "application/json"));
            
            await context.HttpContext.Response.WriteAsync(
                JsonConvert.SerializeObject(response));
        }
    }
}