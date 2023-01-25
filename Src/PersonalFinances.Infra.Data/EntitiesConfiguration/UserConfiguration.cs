using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinances.Domain.Entities;

namespace PersonalFinances.Infra.Data.EntitiesConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).UseIdentityColumn();

        builder.Property(u => u.Username).IsRequired().HasMaxLength(20);

        builder.Property(u => u.Email).IsRequired().HasMaxLength(100);

        builder.Property(u => u.Password).IsRequired().HasMaxLength(100);

        builder.Property(u => u.CreationDate).IsRequired();

        builder.HasOne(u => u.UserRole).WithMany(u => u.Users).HasForeignKey(u => u.UserRoleId);
        builder.Property(u => u.UserRoleId).IsRequired();

        builder.Property(u => u.IsEmailValid).IsRequired();

        

        builder.HasData
        (
            CreateAdmin()
        );
    }

    private User CreateAdmin()
    {
        User user = new User("Admin", "admin@admin", "Admin123@", 2);
        user.UpdateIsEmailValid();
        return user;
    }
}

