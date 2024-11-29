namespace LibraryManagement.Api.Controllers;

[ApiController]
[Route("api/users")]
public sealed class UsersController : ControllerBase
{
    [HttpPost]
    public ActionResult Post()
    {
        return Created();
    }
}