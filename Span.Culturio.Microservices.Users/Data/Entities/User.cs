using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Span.Culturio.Microservices.Core.Helpers;

namespace Span.Culturio.Microservices.Users.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public int RoleId { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public virtual Role Role { get; set; }

    }

    public class UserConfigurationBuilder : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName)
                .IsRequired();
            builder.Property(x => x.LastName)
                .IsRequired();
            builder.Property(x => x.Email)
                .IsRequired();
            builder.Property(x => x.Username)
                .IsRequired();
            builder.Property(x => x.PasswordHash)
                .IsRequired();
            builder.Property(x => x.PasswordSalt)
                .IsRequired();

            builder.HasOne(x => x.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed data
            UserHelper.CreatePasswordHash("Str0ngP@$$w0rd12$%#", out byte[] passwordHash, out byte[] passwordSalt);
            builder.HasData(new User
            {
                Id = 1,
                RoleId = 1,
                FirstName = "Admin",
                LastName = "User",
                Email = "admin@culturio.eu",
                Username = "sysadmin",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            });
        }
    }
}

