using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Span.Culturio.Microservices.Subscriptions.Data.Entities
{
    public class TrackVisit
    {
        public int Id { get; set; }
        public int SubscriptionId { get; set; }
        public int CultureObjectId { get; set; }
        public DateTime TimeEntered { get; set; }

    }

    public class TrackVisitConfigurationBuilder : IEntityTypeConfiguration<TrackVisit>
    {
        public void Configure(EntityTypeBuilder<TrackVisit> builder)
        {
            builder.ToTable(nameof(TrackVisit));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SubscriptionId)
                .IsRequired();
            builder.Property(x => x.CultureObjectId)
                .IsRequired();
            builder.Property(x => x.TimeEntered)
                .IsRequired();

        }
    }
}

