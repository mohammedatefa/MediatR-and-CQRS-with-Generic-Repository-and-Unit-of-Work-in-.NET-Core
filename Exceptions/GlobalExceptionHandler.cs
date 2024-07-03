using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR.Exceptions
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var problemDetails = new ProblemDetails();
            problemDetails.Instance = httpContext.Request.Path;
            if (exception is FluentValidation.ValidationException fluentException)
            {
                problemDetails.Title = "one or more validation errors occurred.";
                problemDetails.Type = "400 Bad Request";
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                List<string> validationErrors = new List<string>();
                foreach (var error in fluentException.Errors)
                {
                    validationErrors.Add(error.ErrorMessage);
                }
                problemDetails.Extensions.Add("errors", validationErrors);
            }
            else
            {
                problemDetails.Title = exception.Message;
            }

            logger.LogError("{ProblemDetailsTitle}", problemDetails.Title);

            problemDetails.Status = httpContext.Response.StatusCode;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken).ConfigureAwait(false);
            return true;
        }
    }
}
