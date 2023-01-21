using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinances.Domain.Entities;

namespace PersonalFinances.Infra.Data.EntitiesConfiguration
{
    public class ExpenditureConfiguration : IEntityTypeConfiguration<Expenditure>
    {
        public void Configure(EntityTypeBuilder<Expenditure> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).UseIdentityColumn();

            builder.Property(r => r.Name).IsRequired().HasMaxLength(30);

            builder.Property(r => r.Date).IsRequired();

            builder.Property(r => r.Value).IsRequired().HasPrecision(18,2);

            builder.Property(r => r.Description).IsRequired().HasMaxLength(60);

            builder.HasOne(r => r.User).WithOne(u => u.Expenditure).HasForeignKey<Expenditure>(e => e.UserId);
            builder.Property(r => r.UserId).IsRequired();

            builder.HasOne(r => r.ExpenditureCategory).WithMany(r => r.Expenditures).HasForeignKey(r => r.ExpenditureCategoryId);
            builder.Property(r => r.ExpenditureCategoryId).IsRequired();
        }
    }
}