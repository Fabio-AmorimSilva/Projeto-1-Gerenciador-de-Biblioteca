namespace LibraryManagement.Application.Services.Users;

public class UsersService(ILibraryDbContext context) : IUsersService
{
    public async Task<ResultDto<Guid>> Create(CreateUserDto dto)
    {
        var isValid = await new CreateUserDtoValidator().ValidateAsync(dto);

        if (!isValid.IsValid)
            return ResultDto<Guid>.Error(isValid.Errors.First().ErrorMessage);

        var userExists = await context.Users
            .WithSpecification(new UserAlreadyExistsSpec(
                name: dto.Name,
                email: dto.Email
            )).AnyAsync();

        if (userExists)
            return ResultDto<Guid>.Error(ErrorMessages.NotFound<User>());

        var user = new User(
            name: dto.Name,
            email: dto.Email
        );

        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();

        return new ResultDto<Guid>(user.Id);
    }
}