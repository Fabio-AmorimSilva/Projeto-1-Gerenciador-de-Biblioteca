namespace LibraryManagement.Application.Dtos;

public class ResultDto
{
    public string? Message { get; private set; }
    public bool IsSuccess { get; private set; }

    public ResultDto(
        bool isSuccess,
        string? message = ""
    )
    {
        Message = message;
        IsSuccess = isSuccess;
    }

    public ResultDto Success()
        => new(isSuccess: true);

    public ResultDto Error(string message)
        => new(
            message: message,
            isSuccess: false
        );
}

public class ResultDto<T> : ResultDto
{
    public T? Data { get; private set; }

    public ResultDto(
        T? data,
        bool isSuccess,
        string? message = ""
    ) : base(isSuccess, message)
    {
        Data = data;
    }

    public ResultDto<T> Success(T data)
        => new(
            data: data,
            isSuccess: true
        );

    public ResultDto<T> Error(string message, T data)
        => new(
            data: data,
            message: message,
            isSuccess: false
        );
}