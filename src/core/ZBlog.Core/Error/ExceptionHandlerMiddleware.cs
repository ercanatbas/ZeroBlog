using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;
using ZBlog.Core.Exceptions;
using ZBlog.Core.Services;
using ZBlog.Core.Services.Result;

namespace ZBlog.Core.Error
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

        public async Task<IServiceResult> HandleExceptionAsync(HttpContext context, Exception exception)
        {
            IServiceResult result;
            if (exception is ZBLogException || exception is JsonSerializationException && exception.InnerException?.InnerException is ZBLogException)
            {
                var zBlogException = (exception is ZBLogException ? exception : exception.InnerException.InnerException) as ZBLogException;
                if (zBlogException is NotValidatedException ex)
                    result = new ServiceResult(ex.ValidationResult.Errors.Select(x => new ServiceError(x.ErrorCode, x.ErrorMessage)).Cast<IServiceError>().ToList(), 400);
                else
                    result = new ServiceResult(new ServiceError(zBlogException?.StatusCode.ToString(), zBlogException?.Message), zBlogException.StatusCode);
            }
            else
                result = new ServiceResult(new ServiceError("500", exception.GetType().Name, exception), 500);

            context.Response.StatusCode = result.Code;
            context.Response.ContentType = "application/json; charset=utf-8";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(result));

            // TODO: Log add
            return result;
        }
    }
}
