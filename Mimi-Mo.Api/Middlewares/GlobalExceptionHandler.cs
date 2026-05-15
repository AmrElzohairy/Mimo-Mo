using FluentValidation; 
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace Mimi_Mo.Api.Middlewares;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, 
        Exception exception, 
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "An unhandled exception occurred: {Message}", exception.Message);

        // 1. Determine Status Code
        var statusCode = exception switch
        {
            ValidationException => (int)HttpStatusCode.BadRequest,
            UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
            KeyNotFoundException => (int)HttpStatusCode.NotFound,
            _ => (int)HttpStatusCode.InternalServerError
        };

        // 2. Extract Errors (Fixes the "Cannot resolve symbol Errors" issue)
        List<string> errors = exception switch
        {
            ValidationException fluentException => fluentException.Errors
                .Select(e => e.ErrorMessage)
                .ToList(),
        
            KeyNotFoundException notFoundException => new List<string> { notFoundException.Message },
    
            _ => new List<string> { "An unexpected error occurred." }
        };
        
        // In Development, you might want the actual exception message for non-validation errors
        if (exception is not ValidationException && statusCode == 500)
        {
            // You can refine this logic based on Environment
            errors = new List<string> { exception.Message };
        }

        httpContext.Response.StatusCode = statusCode;

        var response = new 
        { 
            Status = statusCode, 
            Errors = errors,
            Timestamp = DateTime.UtcNow
        };

        await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

        return true; 
    }
}