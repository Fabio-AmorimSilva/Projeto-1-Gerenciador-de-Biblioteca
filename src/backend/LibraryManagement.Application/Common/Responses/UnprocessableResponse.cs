namespace LibraryManagement.Application.Common.Responses;

public class UnprocessableResponse<T> : ApiResponse<T>
{
    public UnprocessableResponse(string message)
    {
        Message = message;
        StatusCode = 422;
        IsSuccess = false;
    }
}