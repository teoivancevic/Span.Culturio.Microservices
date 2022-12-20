using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Span.Culturio.Microservices.CultureObjects.Data.Entities
{
    public class CultureObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public int CompanyId { get; set; }
        public string ContactEmail { get; set; }
        public int ZipCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int AdminUserId { get; set; }
    }

    public class CultureObjectConfigurationBuilder : IEntityTypeConfiguration<CultureObject>
    {
        public void Configure(EntityTypeBuilder<CultureObject> builder)
        {
            builder.ToTable(nameof(CultureObject));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired();
            builder.Property(x => x.ContactEmail)
                .IsRequired();
            builder.Property(x => x.ZipCode)
                .IsRequired();
            builder.Property(x => x.Address)
                .IsRequired();
            builder.Property(x => x.City)
                .IsRequired();
            builder.Property(x => x.AdminUserId)
                .IsRequired();


            //seed
            builder.HasData(new CultureObject
            {
                Id = 1,
                Name = "Mimara",
                ContactEmail = "mimara@mimara.hr",
                ZipCode = 10000,
                Address = "centar grada",
                City = "Zagreb",
                AdminUserId = 1
            });

            builder.HasData(new CultureObject
            {
                Id = 2,
                Name = "Kino Branimir",
                ContactEmail = "branimir@blitz.hr",
                ZipCode = 10000,
                Address = "branimir centar",
                City = "Zagreb",
                AdminUserId = 1
            });

            builder.HasData(new CultureObject
            {
                Id = 3,
                Name = "Kino Arena centar",
                ContactEmail = "arenacentar@blitz.hr",
                ZipCode = 10000,
                Address = "Arena centar",
                City = "Zagreb",
                AdminUserId = 1
            });
        }
    }
}

