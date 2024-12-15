namespace LibraryManagement.Api.Controllers;

[ApiController]
[Route("api/users")]
public sealed class UsersController(IUsersService service) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Post(CreateUserDto dto)
    {
        await service.Create(dto);

        return Created();
    }
}