namespace LibraryManagement.Api.Controllers;

[ApiController]
[Route("api/books")]
public sealed class BooksController(IBooksService service) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Post(CreateBookDto dto)
    {
        var bookId = await service.Create(dto);

        return Created();
    }

    [HttpGet("list")]
    public async Task<ActionResult> ListBooks()
    {
        var books = await service.List();

        return Ok(books);
    }

    [HttpDelete("{bookId:guid}")]
    public async Task<ActionResult> Delete(Guid bookId)
    {
        await service.Delete(bookId);

        return NoContent();
    }

    [HttpGet("get/{bookId:guid}")]
    public async Task<ActionResult> GetBook(Guid bookId)
    {
        var book = await service.Get(bookId);

        return Ok(book);
    }

    [HttpPut("{userId:Guid}/{bookId:guid}/loan")]
    public async Task<ActionResult> LoanBook(Guid userId, Guid bookId, DateTime loanDate)
    {
        await service.Loan(userId, bookId, loanDate);

        return NoContent();
    }

    [HttpPut("{bookId:guid}/dropoff")]
    public async Task<ActionResult> DropOff(Guid bookId, DateTime dropOff)
    {
        await service.DropOff(bookId, dropOff);

        return NoContent();
    }
}