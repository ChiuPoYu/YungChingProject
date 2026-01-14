using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApi.Models.ResponseModel;
using YungChingWebApi.Resources.Exceptions;

namespace YungChingWebApi.Resources.Filters
{
    /// <summary>
    /// HTTP 例外過濾器，用於統一處理 HttpException
    /// </summary>
    public class HttpExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<HttpExceptionFilter> _logger;

        public HttpExceptionFilter(ILogger<HttpExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is HttpException httpException)
            {
                _logger.LogWarning(
                    httpException,
                    "HttpException occurred: StatusCode={StatusCode}, ErrorCode={ErrorCode}, Message={Message}",
                    httpException.StatusCode,
                    httpException.ErrorCode,
                    httpException.Message);

                var response = new ResultResponse(
                    success: false,
                    message: httpException.Message,
                    errorCode: httpException.ErrorCode);

                context.Result = new ObjectResult(response)
                {
                    StatusCode = httpException.StatusCode
                };

                context.ExceptionHandled = true;
            }
        }
    }
}
