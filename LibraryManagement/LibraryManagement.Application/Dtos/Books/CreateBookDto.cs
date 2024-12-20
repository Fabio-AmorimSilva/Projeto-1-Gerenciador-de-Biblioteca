namespace LibraryManagement.Application.Dtos.Books;

public sealed record CreateBookDto(
    string Isbn,
    string Author,
    string Title,
    string Genre,
    int Year
);

public class CreateBookDtoValidator : AbstractValidator<CreateBookDto>
{
    public CreateBookDtoValidator()
    {
        RuleFor(dto => dto.Isbn)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateBookDto.Isbn)));
        
        RuleFor(dto => dto.Author)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateBookDto.Author)))
            .MaximumLength(Book.AuthorMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(CreateBookDto.Author), Book.AuthorMaxLength));
        
        RuleFor(dto => dto.Title)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateBookDto.Title)))
            .MaximumLength(Book.TitleMaxLength)
            .WithMessage(ErrorMessages.HasMaxLength(nameof(CreateBookDto.Title), Book.TitleMaxLength));
        
        RuleFor(dto => dto.Genre)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateBookDto.Genre)));
        
        RuleFor(dto => dto.Year)
            .NotEmpty()
            .WithMessage(ErrorMessages.CannotBeEmpty(nameof(CreateBookDto.Year)));
    }
}
