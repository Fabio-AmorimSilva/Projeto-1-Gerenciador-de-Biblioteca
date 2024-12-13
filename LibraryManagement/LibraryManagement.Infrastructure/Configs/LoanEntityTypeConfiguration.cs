namespace LibraryManagement.Infrastructure.Configs;

public class LoanEntityTypeConfiguration : IEntityTypeConfiguration<Loan>
{
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
        builder
            .ToTable("Loans");
        
        builder
            .HasKey(l => l.Id);

        builder
            .HasOne(l => l.Book)
            .WithOne()
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(l => l.User)
            .WithMany()
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Property(l => l.DropOff)
            .IsRequired();
    }
}