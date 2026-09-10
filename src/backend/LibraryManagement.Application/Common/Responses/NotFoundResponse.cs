namespace LibraryManagement.Application.Common.Responses;

public class NotFoundResponse<T> : ApiResponse<T>
{
    public NotFoundResponse(string message)
    {
        Message = message;
        StatusCode = 404;
        IsSuccess = false;
    }
}