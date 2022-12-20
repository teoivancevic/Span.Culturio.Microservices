using System;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Span.Culturio.Microservices.CultureObjects.Data.Entities;

namespace Span.Culturio.Microservices.CultureObjects.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        //public DbSet<User> Users { get; set; }
        //public DbSet<Subscription> Subscriptions { get; set; }
        //public DbSet<Package> Packages { get; set; }
        //public DbSet<PackageCultureObject> PackageCultureObjects { get; set; }
        public DbSet<CultureObject> CultureObjects { get; set; }
        //public DbSet<TrackVisit> TrackVisits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<Package>()
                .HasMany(p => p.CultureObjects)
                .WithOne(b => b.Package)
                .HasForeignKey(x => x.PackageId);
            */
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //SeedData.CreateData(modelBuilder);
        }
    }
}

