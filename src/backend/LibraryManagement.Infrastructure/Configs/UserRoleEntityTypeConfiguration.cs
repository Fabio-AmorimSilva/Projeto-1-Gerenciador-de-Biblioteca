namespace LibraryManagement.Infrastructure.Configs;

public class UserRoleEntityTypeConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder
            .ToTable("UserRoles");

        builder
            .HasKey(rp => new
            {
                rp.RoleId,
                rp.UserId
            });

        builder
            .Property(rp => rp.RoleId)
            .IsRequired();

        builder
            .Property(rp => rp.UserId)
            .IsRequired();
    }
}