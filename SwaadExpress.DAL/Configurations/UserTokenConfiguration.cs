using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwaadExpress.Domain.Modal.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwaadExpress.DAL.Configurations
{
    public class UserTokenConfiguration : IEntityTypeConfiguration<UserTokenEntity>
    {
        public void Configure(EntityTypeBuilder<UserTokenEntity> builder)
        {

            builder.ToTable("UserToken");
            builder.HasKey(x => x.UserRefreshTokenId);

            builder.Property(x => x.Token)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(x => x.RefreshToken)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(x=> x.CreatedAt)
                .HasColumnType("timestamp with time zone")
                 .IsRequired();

            builder.Property(x => x.ExpirationTime)
                .HasColumnType("timestamp with time zone")
                .IsRequired();

            builder.Property(x => x.IsInvalidated)
                .IsRequired();

            builder.Property(x => x.UserId)
                .IsRequired();

        }
         
    }
}
