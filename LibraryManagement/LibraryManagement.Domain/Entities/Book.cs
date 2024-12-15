namespace LibraryManagement.Domain.Entities;

public class Book : Entity
{
    public const int TitleMaxLength = 500;
    public const int AuthorMaxLength = 500;

    public string Isbn { get; private set; } = null!;
    public string Title { get; private set; } = null!;
    public string Author { get; private set; } = null!;
    public string Genre { get; private set; } = null!;
    public int Year { get; private set; }

    protected Book()
    {
    }

    public Book(
        string isbn,
        string title,
        string author,
        string genre,
        int year
    )
    {
        Guard.IsNotWhiteSpace(isbn);
        Guard.IsNotWhiteSpace(title);
        Guard.IsLessThanOrEqualTo(title.Length, TitleMaxLength, nameof(title));
        Guard.IsNotWhiteSpace(author);
        Guard.IsLessThanOrEqualTo(author.Length, AuthorMaxLength, nameof(author));
        Guard.IsNotDefault(year);

        Isbn = isbn;
        Title = title;
        Author = author;
        Genre = genre;
        Year = year;
    }
}