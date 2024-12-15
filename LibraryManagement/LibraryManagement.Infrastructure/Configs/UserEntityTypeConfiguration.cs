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
            .Property(u => u.Name)
            .HasMaxLength(User.NameMaxLength)
            .IsRequired();
        
        builder
            .Property(u => u.Email)
            .HasMaxLength(User.EmailMaxLength)
            .IsRequired();
    }
}