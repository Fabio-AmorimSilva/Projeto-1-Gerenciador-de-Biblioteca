namespace LibraryManagement.Application.Services.Books;

public interface IBooksService
{
    Task<ResultDto<Guid>> Create(CreateBookDto dto);
    Task<ResultDto> Loan(Guid userId, Guid bookId, DateTime loanDate);
    Task<ResultDto> DropOff(Guid bookId, DateTime dropOff);
    Task<ResultDto> Delete(Guid bookId);
    Task<ResultDto<GetBookResponseDto>> Get(Guid bookId);
    Task<ResultDto<IEnumerable<GetBookResponseDto>>> List();
}