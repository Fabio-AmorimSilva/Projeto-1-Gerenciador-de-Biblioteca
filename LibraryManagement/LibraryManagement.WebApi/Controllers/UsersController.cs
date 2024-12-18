namespace LibraryManagement.Api.Controllers;

[ApiController]
[Route("api/users")]
public sealed class UsersController(IUsersService service) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Post(CreateUserDto dto)
    {
        var response = await service.Create(dto);

        if (!response.IsSuccess)
            return BadRequest(response);
        
        return Ok(response.Data);
    }
}