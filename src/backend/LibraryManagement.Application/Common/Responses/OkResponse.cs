namespace LibraryManagement.Application.Common.Responses;

public class OkResponse<T> : ApiResponse<T>
{
    public OkResponse(T data)
    {
        Data = data;
        StatusCode = 200;
        IsSuccess = true;
    }
}