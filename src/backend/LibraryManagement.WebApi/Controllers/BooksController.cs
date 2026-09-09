using LibraryManagement.Application.Dtos;

namespace LibraryManagement.Api.Controllers;

[ApiController]
[Route("api/books")]
public sealed class BooksController(IBooksService service) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResultDto), StatusCodes.Status201Created)]
    public async Task<ActionResult> Post(CreateBookDto dto)
    {
        var response = await service.Create(dto);

        if (!response.IsSuccess)
            return BadRequest(response.Message);

        return Ok(response.Data);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResultDto<IEnumerable<GetBookResponseDto>>), StatusCodes.Status200OK)]
    public async Task<ActionResult> ListBooks()
    {
        var books = await service.List();

        return Ok(books.Data);
    }

    [HttpDelete("{bookId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Delete(Guid bookId)
    {
        var response = await service.Delete(bookId);

        if (!response.IsSuccess)
            return BadRequest(response.Message);

        return NoContent();
    }

    [HttpGet("genres")]
    [ProducesResponseType(typeof(ResultDto<IEnumerable<string>>), StatusCodes.Status200OK)]
    public ActionResult ListGenres()
    {
        var response = service.ListGenres();

        return Ok(response.Data);
    }

    [HttpPut("{bookId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Update(Guid bookId, UpdateBookDto dto)
    {
        var response = await service.Update(bookId, dto);

        if (!response.IsSuccess)
            return BadRequest(response.Message);

        return NoContent();
    }

    [HttpGet("{bookId:guid}")]
    [ProducesResponseType(typeof(ResultDto<GetBookResponseDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult> GetBook(Guid bookId)
    {
        var response = await service.Get(bookId);

        if (!response.IsSuccess)
            return BadRequest(response.Message);
        
        return Ok(response.Data);
    }

    [HttpPut("{userId:Guid}/{bookId:guid}/loan")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> LoanBook(Guid userId, Guid bookId, DateTime loanDate)
    {
        var response = await service.Loan(userId, bookId, loanDate);

        if (!response.IsSuccess)
            return BadRequest(response.Message);

        return NoContent();
    }

    [HttpPut("{bookId:guid}/drop-off")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DropOff(Guid bookId, DateTime dropOff)
    {
        var response = await service.DropOff(bookId, dropOff);

        if (!response.IsSuccess)
            return BadRequest(response.Message);

        return Ok(response.Message);
    }
}