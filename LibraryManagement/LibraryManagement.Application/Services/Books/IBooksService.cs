namespace LibraryManagement.Application.Services.Books;

public interface IBooksService
{
    ResultDto<Guid> Create(CreateBookDto dto);
    ResultDto<Guid> DropOff(Guid bookId, DateTime dropOff);
    ResultDto<IEnumerable<GetBookResponseDto>> List();
    ResultDto<GetBookResponseDto> Get(Guid bookId);
    ResultDto<Guid> Delete(Guid bookId);
    ResultDto<Guid> Loan(Guid bookId, DateTime dropOff);
}