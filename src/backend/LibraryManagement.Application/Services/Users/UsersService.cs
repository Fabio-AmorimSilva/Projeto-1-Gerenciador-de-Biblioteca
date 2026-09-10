namespace LibraryManagement.Application.Services.Users;

public class UsersService(
    ILibraryDbContext context,
    ITokenService tokenService
) : IUsersService
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
                )
            ).AnyAsync();

        if (userExists)
            return ResultDto<Guid>.Error(ErrorMessages.AlreadyExists<User>());

        var user = new User(
            name: dto.Name,
            email: dto.Email,
            password: dto.Password
        );

        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();

        return new ResultDto<Guid>(user.Id);
    }

    public async Task<ResultDto<string>> Login(LoginUserDto dto)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
        
        if(user is null)
            return new NotFoundResponse<string>(ErrorMessages.NotFound<User>());

        var token = tokenService.GenerateToken(
            roles: dto.Roles,
            permissions: dto.Permissions,
            user: user
        );

        return new ResultDto<string>(token);
    }
}