namespace LibraryManagement.Api.Controllers;

[ApiController]
[Route("api/books")]
public sealed class BooksController : ControllerBase
{
    [HttpPost]
    public ActionResult Post()
    {
        return Created();
    }
    
    [HttpGet("list")]
    public ActionResult ListBooks()
    {
        return Ok();
    }
    
    [HttpDelete]
    public ActionResult Delete()
    {
        return NoContent();
    }
    
    [HttpGet("get")]
    public ActionResult GetBook()
    {
        return Ok();
    }

    [HttpPut("loan")]
    public ActionResult LoanBook()
    {
        return NoContent();
    }

    [HttpPut("dropoff")]
    public ActionResult DropOff()
    {
        return NoContent();
    }
}