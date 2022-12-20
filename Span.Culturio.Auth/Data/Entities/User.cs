﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Span.Culturio.Auth.Helpers;

namespace Span.Culturio.Auth.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
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


            /*
            // Seed data
            UserHelper.CreatePasswordHash("Str0ngP@$$w0rd12$%#", out byte[] passwordHash, out byte[] passwordSalt);
            builder.HasData(new User
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "User",
                Email = "admin@culturio.eu",
                Username = "sysadmin",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            });
            */
        }
    }
}

