using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AddressSearch.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace AddressSearch.Infrastructure.Middlewares
{
    /// <summary>
    /// 
    /// </summary>
    public class ErrorHandlingMiddleware
    {

        private readonly RequestDelegate _next;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
       
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
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
            // Default: If it's not one of the expected exception
            HttpStatusCode code = HttpStatusCode.InternalServerError;

            switch (exception)
            {
                case ArgumentNullException _:
                    code = HttpStatusCode.BadRequest;
                    break;

                case HttpRequestException _:
                    code = HttpStatusCode.BadRequest;
                    break;

                case UnauthorizedAccessException _:
                    code = HttpStatusCode.Unauthorized;
                    break;
                case ArgumentOutOfRangeException _:
                    code = HttpStatusCode.NotFound;
                    break;
            }

            return WriteExceptionAsync(context, exception, code);
        }

        private static Task WriteExceptionAsync(HttpContext context, Exception exception, HttpStatusCode code)
        {
            HttpResponse response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)code;
            return response.WriteAsync(JsonConvert.SerializeObject(new
            {
                error = new ErrorResponseModel
                {
                    Code = (int)code,
                    Message = exception.Message,
                    Exception = exception.GetType().Name
                }
            }));
        }
    }
}
