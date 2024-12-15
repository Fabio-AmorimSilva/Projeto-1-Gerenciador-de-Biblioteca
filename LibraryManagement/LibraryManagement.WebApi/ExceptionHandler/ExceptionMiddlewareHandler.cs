namespace LibraryManagement.Api.ExceptionHandler;

public class ExceptionMiddlewareHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken
    )
    {
        var error = new
        {
            exception.Message,
            exception.StackTrace,
            exception.InnerException
        };

        await httpContext.Response.WriteAsJsonAsync(error, cancellationToken: cancellationToken);

        return true;
    }
}