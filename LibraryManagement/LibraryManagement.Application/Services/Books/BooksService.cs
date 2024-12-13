namespace LibraryManagement.Application.Services.Books;

public class BooksService(ILibraryDbContext context) : IBooksService
{
    public async Task<ResultDto<Guid>> Create(CreateBookDto dto)
    {
        var isValid = await new CreateBookDtoValidator().ValidateAsync(dto);

        if (isValid.IsValid)
            return ResultDto<Guid>.Error(isValid.Errors.First().ErrorMessage);

        var book = new Book(
            isbn: dto.Isbn,
            title: dto.Title,
            author: dto.Author,
            genre: dto.Genre,
            year: dto.Year
        );

        await context.Books.AddAsync(book);
        await context.SaveChangesAsync();

        return new ResultDto<Guid>(book.Id);
    }

    public async Task<ResultDto> Loan(Guid userId, Guid bookId, DateTime loanDate)
    {
        var loanExists = await context.Loans
            .Include(l => l.Book)
            .AnyAsync(l => l.BookId == bookId);

        if (!loanExists)
            return new ResultDto();

        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (user is null)
            return new ResultDto();

        var book = await context.Books.FirstOrDefaultAsync(b => b.Id == bookId);
        if (book is null)
            return new ResultDto();

        var loan = new Loan(
            user: user,
            book: book,
            loanDate: loanDate
        );

        await context.Loans.AddAsync(loan);
        await context.SaveChangesAsync();

        return new ResultDto();
    }

    public async Task<ResultDto> DropOff(Guid bookId, DateTime dropOff)
    {
        var loan = await context.Loans
            .Include(l => l.Book)
            .FirstOrDefaultAsync(l => l.BookId == bookId);

        if (loan is null)
            return new ResultDto();

        loan.DropOffBook(dropOff: dropOff);

        await context.SaveChangesAsync();

        return new ResultDto<Guid>(loan.Id);
    }

    public async Task<ResultDto> Delete(Guid bookId)
    {
        var book = await context.Books.FirstOrDefaultAsync(b => b.Id == bookId);

        if (book is null)
            return new ResultDto();

        context.Books.Remove(book);
        await context.SaveChangesAsync();

        return new ResultDto();
    }

    public async Task<ResultDto<GetBookResponseDto>> Get(Guid bookId)
    {
        var book = await context.Books
            .Where(b => b.Id == bookId)
            .Select(b => new GetBookResponseDto
            {
                Isbn = b.Isbn,
                Author = b.Author,
                Title = b.Title,
                Genre = b.Genre,
                Year = b.Year
            })
            .FirstOrDefaultAsync();

        if (book is null)
            return new ResultDto<GetBookResponseDto>(null);

        return new ResultDto<GetBookResponseDto>(book);
    }

    public async Task<ResultDto<IEnumerable<GetBookResponseDto>>> List()
    {
        var books = await context.Books
            .Select(b => new GetBookResponseDto
            {
                Isbn = b.Isbn,
                Author = b.Author,
                Title = b.Title,
                Genre = b.Genre,
                Year = b.Year
            }).ToListAsync();

        return new ResultDto<IEnumerable<GetBookResponseDto>>(books);
    }
}