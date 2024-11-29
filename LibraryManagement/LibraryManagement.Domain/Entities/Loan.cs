namespace LibraryManagement.Domain.Entities;

public class Loan : Entity
{
    public Guid UserId { get; private set; }
    public User User { get; private set; }
    public Guid BookId { get; private set; }
    public Book Book { get; private set; }
    public DateTime DropOff { get; private set; }

    protected Loan()
    {
    }

    public Loan(
        Guid userId,
        User user,
        Guid bookId,
        Book book,
        DateTime dropOff
    )
    {
        UserId = userId;
        User = user;
        BookId = bookId;
        Book = book;
        DropOff = dropOff;
    }
}