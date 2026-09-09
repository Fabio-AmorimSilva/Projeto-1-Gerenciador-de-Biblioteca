namespace LibraryManagement.Application.Dtos.Books;

public sealed record UpdateBookDto(
    string Isbn,
    string Author,
    string Title,
    Genre Genre,
    int Year
);

public class UpdateBookDtoValidator : AbstractValidator<UpdateBookDto>
{
    public UpdateBookDtoValidator()
    {
        RuleFor(dto => dto.Isbn)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateBookDto.Isbn)));

        RuleFor(dto => dto.Author)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateBookDto.Author)))
            .MaximumLength(Book.AuthorMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(UpdateBookDto.Author), Book.AuthorMaxLength));

        RuleFor(dto => dto.Title)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateBookDto.Title)))
            .MaximumLength(Book.TitleMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(UpdateBookDto.Title), Book.TitleMaxLength));

        RuleFor(dto => dto.Genre)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateBookDto.Genre)));

        RuleFor(dto => dto.Year)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(UpdateBookDto.Year)));
    }
}
