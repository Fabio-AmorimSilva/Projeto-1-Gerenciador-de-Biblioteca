namespace LibraryManagement.Infrastructure.Configs;

public class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder
            .ToTable("Books");
        
        builder
            .HasKey(b => b.Id);

        builder
            .Property(b => b.Isbn)
            .IsRequired();

        builder
            .Property(b => b.Title)
            .IsRequired();

        builder
            .Property(b => b.Author)
            .IsRequired();

        builder
            .Property(b => b.Genre)
            .IsRequired();

        builder
            .Property(b => b.Year)
            .IsRequired();
    }
}