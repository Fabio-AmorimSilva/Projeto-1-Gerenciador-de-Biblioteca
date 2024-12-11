namespace LibraryManagement.Application.Services.Books;

public class BooksService(ILibraryDbContext context) : IBooksService
{
    public ResultDto<Guid> Create(CreateBookDto dto)
    {
        throw new NotImplementedException();
    }

    public ResultDto<Guid> DropOff(Guid bookId, DateTime dropOff)
    {
        throw new NotImplementedException();
    }

    public ResultDto<IEnumerable<GetBookResponseDto>> List()
    {
        throw new NotImplementedException();
    }

    public ResultDto<GetBookResponseDto> Get(Guid bookId)
    {
        throw new NotImplementedException();
    }

    public ResultDto<Guid> Delete(Guid bookId)
    {
        throw new NotImplementedException();
    }

    public ResultDto<Guid> Loan(Guid bookId, DateTime dropOff)
    {
        throw new NotImplementedException();
    }
}