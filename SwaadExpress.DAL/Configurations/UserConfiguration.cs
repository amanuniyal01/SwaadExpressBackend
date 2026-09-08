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
                .HasMaxLength(100);
                //.IsRequired();

            builder.Property(u => u.Email)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(u => u.IsEmailVerified)
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(u => u.RoleId)
                 .IsRequired();

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.IsDeleted)
                .HasDefaultValue(false);

            builder.Property(u => u.IsBlocked)
                .HasDefaultValue(false);

            builder.Property(u => u.CreatedAt)
             .HasColumnType("timestamp with time zone")
             .IsRequired();

            builder.Property(u => u.UpdatedAt)
                .HasColumnType("timestamp with time zone");


            builder.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
