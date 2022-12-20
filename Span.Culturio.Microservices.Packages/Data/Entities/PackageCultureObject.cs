using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Span.Culturio.Microservices.Packages.Data.Entities
{
    public class PackageCultureObject
    {
        public int Id { get; set; }
        //public int SubscriptionId { get; set; }
        public int CultureObjectId { get; set; }




        [ForeignKey("Package")]
        public int PackageId { get; set; }
        //nezz dal se ovo ovako radi
        //public Package Package { get; set; }

        public int AvailableVisits { get; set; }

        public virtual Package Package { get; set; }
    }

    public class PackageCultureObjectConfigurationBuilder : IEntityTypeConfiguration<PackageCultureObject>
    {
        public void Configure(EntityTypeBuilder<PackageCultureObject> builder)
        {
            builder.ToTable(nameof(PackageCultureObject));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CultureObjectId)
                .IsRequired();
            //builder.Property(x => x.CultureObjects)
            //    .IsRequired();
            builder.Property(x => x.PackageId)
                .IsRequired();
            builder.Property(x => x.AvailableVisits)
                .IsRequired();

        }
    }
}

