using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ZuzexTestProject.Infrastructure.Exceptions;

namespace ZuzexTestProject.UI.Middlewares
{
    public class ErrorResponse
    {
        [JsonPropertyName("code")]
        public int ErrorCode { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }

    public class CustomAppErrorCodes
    {
        private readonly RequestDelegate _next;

        public CustomAppErrorCodes(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (AppException ex)
            {
                int statusCode = (int)HttpStatusCode.InternalServerError;

                var error = new ErrorResponse
                {
                    ErrorCode = (int)ex.ErrorCode,
                    Message = ex.Message
                };

                string json = JsonSerializer.Serialize(error);

                if (ex is BadInputException)
                {
                    statusCode = (int)HttpStatusCode.BadRequest;
                }

                if (ex is NotFoundException)
                {
                    statusCode = (int)HttpStatusCode.NotFound;
                }

                context.Response.ContentType = "application/json; charset=utf-8";
                context.Response.StatusCode = statusCode;

                await context.Response.WriteAsync(json);
            }
        }
    }
}
