namespace LibraryManagement.Application.Common.Responses;

public abstract class ApiResponse<T> : ResultDto<T>
{
    public int StatusCode { get; set; }
}