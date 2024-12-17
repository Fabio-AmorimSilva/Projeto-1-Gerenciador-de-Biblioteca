namespace LibraryManagement.Application.Dtos.Users;

public sealed record CreateUserDto(
    string Name,
    string Email
);

public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateUserDto.Name)));

        RuleFor(dto => dto.Email)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateUserDto.Email)));
    }
}