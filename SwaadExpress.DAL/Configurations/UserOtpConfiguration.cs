using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwaadExpress.Domain.Modal.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwaadExpress.DAL.Configurations
{
    public class UserOtpConfiguration : IEntityTypeConfiguration<UserOtpEntity>
    {
        public void Configure(EntityTypeBuilder<UserOtpEntity> builder)
        {
            builder.ToTable("UserOtps");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Otp)
                .IsRequired()
                .HasMaxLength(4);

            builder.HasIndex(u => u.Email).IsUnique();


            builder.Property(u => u.ExpiryTime)
                .HasColumnType("timestamp with time zone")
                .IsRequired();

            builder.Property(u => u.TryCount)
                .IsRequired()
                .HasDefaultValue(1);

            builder.Property(u => u.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                 .HasColumnType("timestamp with time zone");

            //One to One Relationship
            builder.HasOne(u => u.User)
           .WithOne(o => o.Otp)
           .HasForeignKey<UserOtpEntity>(o => o.UserId)
           .OnDelete(DeleteBehavior.Cascade);
                
        }
    }
}
