using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Span.Culturio.Microservices.Subscriptions.Data.Entities
{
    public class Subscription
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PackageId { get; set; }
        public string Name { get; set; }
        public DateTime ActiveFrom { get; set; }
        public DateTime ActiveTo { get; set; }
        public string State { get; set; }
        public int RecordedVisits { get; set; }
    }

    public class SubscriptionConfigurationBuilder : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder.ToTable(nameof(Subscription));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserId)
                .IsRequired();
            builder.Property(x => x.PackageId)
                .IsRequired();
            builder.Property(x => x.Name)
                .IsRequired();
            builder.Property(x => x.ActiveFrom)
                .IsRequired();
            builder.Property(x => x.ActiveTo)
                .IsRequired();
            builder.Property(x => x.State)
                .IsRequired();
            builder.Property(x => x.RecordedVisits)
                .IsRequired();
        }
    }
}

