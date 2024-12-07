using CarRental.Application.Common.Exceptions;
using FluentValidation;
using System.Text.Json;

namespace CarRental.Api.Middlewares
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) => _logger = logger;
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                await HandleExceptionAsync(context, e);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var statusCode = GetStatusCode(exception);
            var response = new
            {
                title = GetTitle(exception),
                status = statusCode,
                errors = GetErrors(exception)
            };
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
        private static int GetStatusCode(Exception exception) =>
            exception switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError
            };
        private static string GetTitle(Exception exception) =>
            exception switch
            {
                NotFoundException => "Not Found",
                ValidationException => "Validation Error",
                _ => "Server Error"
            };
        private static IEnumerable<object> GetErrors(Exception exception)
        {
            IEnumerable<object> errors = null;
            if (exception is ValidationException validationException)
            {
                errors = validationException.Errors.Select(y => new  { ErrorMessage = y.ErrorMessage, PropertyName = y.PropertyName});
            }
            return errors;
        }
    }
}
