using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Span.Culturio.Microservices.Users.Data.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }

    public class RoleConfigurationBuilder : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(nameof(Role));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired();


            // Seed roles
            builder.HasData(new Role[]
            {
                new Role
                {
                    Id = 1,
                    Name = "PlatformAdmin"
                },
                new Role
                {
                    Id = 2,
                    Name = "CultureObjectAdmin"
                },
                new Role
                {
                    Id = 3,
                    Name = "User"
                }
            });
        }
    }
}

