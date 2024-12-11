namespace LibraryManagement.Application.Dtos.Books;

public sealed record GetBookResponseDto(
    string Isbn,
    string Author,
    string Title,
    string Genre,
    int Year
);