namespace LibraryManagement.Application.Services.Users;

public class UsersService(ILibraryDbContext context) : IUsersService
{
    public ResultDto<Guid> Create()
    {
        throw new NotImplementedException();
    }
}