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
    
    [HttpGet]
    public ActionResult ListBooks()
    {
        return Ok();
    }
    
    [HttpDelete]
    public ActionResult Delete()
    {
        return NoContent();
    }
    
    [HttpGet]
    public ActionResult GetBook()
    {
        return Ok();
    }

    [HttpPut]
    public ActionResult LoanBook()
    {
        return NoContent();
    }

    [HttpPut]
    public ActionResult DropOff()
    {
        return NoContent();
    }
}