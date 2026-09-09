namespace LibraryManagement.Application.Services.Users;

public interface IUsersService
{
    Task<ResultDto<Guid>> Create(CreateUserDto dto);
}