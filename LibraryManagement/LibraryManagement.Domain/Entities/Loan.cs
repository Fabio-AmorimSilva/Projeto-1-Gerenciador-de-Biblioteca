namespace LibraryManagement.Domain.Entities;

public class Loan : Entity
{
    public Guid UserId { get; private set; }
    public User User { get; private set; } = null!;
    public Guid BookId { get; private set; }
    public Book Book { get; private set; } = null!;
    public DateTime DropOff { get; private set; }
    public DateTime LoanDate { get; private set; }

    protected Loan()
    {
    }

    public Loan(
        User user,
        Book book,
        DateTime loanDate
    )
    {
        Guard.IsNotDefault(loanDate);
        
        User = user;
        UserId = user.Id;
        Book = book;
        BookId = book.Id;
        LoanDate = loanDate;
    }

    public void DropOffBook(DateTime dropOff)
    {
        DropOff = dropOff;
    }
}