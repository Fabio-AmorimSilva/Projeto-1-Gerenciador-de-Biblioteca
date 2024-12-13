namespace LibraryManagement.Application.Dtos.Books;

public sealed record GetBookResponseDto
{
    public required string Isbn { get; set; }
    public required string Author { get; set; }
    public required string Title { get; set; }
    public required string Genre { get; set; }
    public required int Year { get; set; }
}