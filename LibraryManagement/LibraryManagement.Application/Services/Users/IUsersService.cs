namespace LibraryManagement.Application.Services.Users;

public interface IUsersService
{
    ResultDto<Guid> Create();
}