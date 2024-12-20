namespace LibraryManagement.Application.Dtos;

public class ResultDto
{
    public string Message { get; private set; } = null!;
    public bool IsSuccess { get; private set; }

    public ResultDto()
    {
        IsSuccess = true;
    }

    protected ResultDto(
        bool isSuccess,
        string message = ""
    )
    {
        Message = message;
        IsSuccess = isSuccess;
    }

    public static ResultDto Success(string message = "")
        => new(
            isSuccess: true,
            message: message
        );

    public static ResultDto Error(string message)
        => new(
            message: message,
            isSuccess: false
        );
}

public class ResultDto<T> : ResultDto
{
    public T? Data { get; private set; }

    public ResultDto(
        T data
    ) : base(isSuccess: true)
    {
        Data = data;
    }

    public ResultDto(
        bool isSuccess = true,
        string message = ""
    ) : base(isSuccess, message)
    {
    }

    public new static ResultDto<T> Error(string message)
        => new(
            message: message,
            isSuccess: false
        );
}