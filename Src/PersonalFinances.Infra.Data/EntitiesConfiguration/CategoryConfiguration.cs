using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinances.Domain.Entities;

namespace PersonalFinances.Infra.Data.EntitiesConfiguration;

public class CategoryConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);
        builder.Property(user => user.Id).UseIdentityColumn();

        builder.Property(user => user.Username).IsRequired().HasMaxLength(20);

        builder.Property(user => user.Email).IsRequired().HasMaxLength(100);

        builder.Property(user => user.Password).IsRequired().HasMaxLength(100);

        builder.Property(user => user.CreationDate).IsRequired();

        builder.HasOne(e => e.UserRole).WithMany(e => e.Users).HasForeignKey(e => e.UserRoleId);
        builder.Property(user => user.UserRoleId).IsRequired();

        builder.Property(user => user.IsEmailValid).IsRequired();
    }
}

