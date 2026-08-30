using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwaadExpress.Domain.Modal.Entity;

namespace SwaadExpress.DAL.Configurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");
            // Configure the UserEntity mapping here (table name, keys, relationships...)
            builder.HasKey(u => u.Id);

            builder.Property(u => u.UserName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(u => u.IsEmailVerified)
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(e => e.RoleId)
                 .IsRequired();

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(e => e.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(e => e.IsBlocked)
                .HasDefaultValue(false);

            builder.Property(e => e.CreatedAt)
                 .HasColumnType("timestamp without time zone")
                 .IsRequired();

            builder.Property(e => e.UpdatedAt)
                 .HasColumnType("timestamp without time zone");
        }
    }
}
