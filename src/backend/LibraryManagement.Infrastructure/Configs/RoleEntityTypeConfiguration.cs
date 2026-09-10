namespace LibraryManagement.Infrastructure.Configs;

public class RoleEntityTypeConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder
            .ToTable("Roles");

        builder
            .HasIndex(p => p.Id);
        
        builder
            .Property(p => p.Name)
            .HasMaxLength(Role.NameMaxLength)
            .IsRequired();
        
        builder
            .HasMany(rp => rp.Permissions)
            .WithOne()
            .HasForeignKey(rp => rp.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}