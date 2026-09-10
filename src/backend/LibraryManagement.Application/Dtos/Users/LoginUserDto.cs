namespace LibraryManagement.Application.Dtos.Users;

public record LoginUserDto(
    string Email, 
    string Password,
    IEnumerable<string> Roles,
    IEnumerable<string> Permissions
);

public class LoginUserDtoValidator : AbstractValidator<LoginUserDto>
{
    public LoginUserDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(LoginUserDto.Email)))
            .EmailAddress()
            .WithMessage(ErrorMessages.EmailIsNotValid(nameof(LoginUserDto.Email)));

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(LoginUserDto.Password)));
    }
}