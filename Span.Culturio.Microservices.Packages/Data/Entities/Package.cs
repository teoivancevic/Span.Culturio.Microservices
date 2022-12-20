using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Span.Culturio.Microservices.Packages.Data.Entities
{
    public class Package
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //nezz dal se ovo ovako radi

        public int ValidDays { get; set; }

        public virtual ICollection<PackageCultureObject> CultureObjects { get; set; }
    }

    public class PackageConfigurationBuilder : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
            builder.ToTable(nameof(Package));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired();
            //builder.Property(x => x.CultureObjects)
            //    .IsRequired();
            builder.Property(x => x.ValidDays)
                .IsRequired();
            /*
            builder.HasMany(p => p.CultureObjects)
                .WithOne(b => b.Package)
                .HasForeignKey(x => x.PackageId);
            */

            builder.HasData(new Package
            {
                Id = 1,
                Name = "Muzeji",
                ValidDays = 15
                
            });

            builder.HasData(new Package
            {
                Id = 2,
                Name = "Kino",
                ValidDays = 30

            });
        }
    }
}

