namespace LibraryManagement.Api.Controllers;

[ApiController]
[Route("api/books")]
public sealed class BooksController(IBooksService service) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Post(CreateBookDto dto)
    {
        var response = await service.Create(dto);

        if (!response.IsSuccess)
            return BadRequest(response.Message);

        return Ok(response.Data);
    }

    [HttpGet("list")]
    public async Task<ActionResult> ListBooks()
    {
        var books = await service.List();

        return Ok(books.Data);
    }

    [HttpDelete("{bookId:guid}")]
    public async Task<ActionResult> Delete(Guid bookId)
    {
        var response = await service.Delete(bookId);

        if (!response.IsSuccess)
            return BadRequest(response.Message);

        return NoContent();
    }

    [HttpGet("get/{bookId:guid}")]
    public async Task<ActionResult> GetBook(Guid bookId)
    {
        var book = await service.Get(bookId);

        return Ok(book.Data);
    }

    [HttpPut("{userId:Guid}/{bookId:guid}/loan")]
    public async Task<ActionResult> LoanBook(Guid userId, Guid bookId, DateTime loanDate)
    {
        var response = await service.Loan(userId, bookId, loanDate);

        if (!response.IsSuccess)
            return BadRequest(response.Message);

        return NoContent();
    }

    [HttpPut("{bookId:guid}/drop-off")]
    public async Task<ActionResult> DropOff(Guid bookId, DateTime dropOff)
    {
        var response = await service.DropOff(bookId, dropOff);

        if (!response.IsSuccess)
            return BadRequest(response.Message);

        return NoContent();
    }
}