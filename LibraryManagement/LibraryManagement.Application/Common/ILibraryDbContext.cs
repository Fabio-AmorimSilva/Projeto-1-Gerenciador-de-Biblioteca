namespace LibraryManagement.Application.Common;

public interface ILibraryDbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Loan> Loans { get; set; }
    public DbSet<User> Users { get; set; }

    new Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}