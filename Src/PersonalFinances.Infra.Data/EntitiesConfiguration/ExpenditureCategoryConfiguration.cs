using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinances.Domain.Entities;

namespace PersonalFinances.Infra.Data.EntitiesConfiguration
{
    public class ExpenditureCategoryConfiguration : IEntityTypeConfiguration<ExpenditureCategory>
    {
        public void Configure(EntityTypeBuilder<ExpenditureCategory> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).UseIdentityColumn();

            builder.Property(e => e.Name).IsRequired().HasMaxLength(30);

            builder.Property(e => e.Description).IsRequired().HasMaxLength(100);

            builder.HasOne(e => e.User).WithMany(u => u.ExpenditureCategories).HasForeignKey(e => e.UserId);
            builder.Property(e => e.UserId).IsRequired();
        }
    }
}