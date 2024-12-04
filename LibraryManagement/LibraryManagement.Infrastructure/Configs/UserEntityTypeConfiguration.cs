namespace LibraryManagement.Infrastructure.Configs;

public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .ToTable("Users");
        
        builder
            .HasKey(u => u.Id);

        builder
            .Property(u => u.Email)
            .IsRequired();

        builder
            .Property(u => u.Name)
            .IsRequired();
    }
}