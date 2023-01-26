using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalFinances.Domain.Entities;

namespace PersonalFinances.Infra.Data.EntitiesConfiguration
{
    public class RevenueConfiguration : IEntityTypeConfiguration<Revenue>
    {
        public void Configure(EntityTypeBuilder<Revenue> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).UseIdentityColumn();

            builder.Property(r => r.Name).IsRequired().HasMaxLength(30);

            builder.Property(r => r.Date).IsRequired();

            builder.Property(r => r.Value).IsRequired().HasPrecision(18,2);

            builder.Property(r => r.Description).IsRequired().HasMaxLength(100);

            builder.HasOne(r => r.User).WithMany(u => u.Revenues).HasForeignKey(r => r.UserId);
            builder.Property(r => r.UserId).IsRequired();

            builder.HasOne(r => r.RevenueCategory).WithMany(r => r.Revenues).HasForeignKey(r => r.RevenueCategoryId);
            builder.Property(r => r.RevenueCategoryId).IsRequired();
        }
    }
}