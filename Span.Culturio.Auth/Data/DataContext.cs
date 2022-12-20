using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Span.Culturio.Auth.Data.Entities;

namespace Span.Culturio.Auth.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        //public DbSet<Subscription> Subscriptions { get; set; }
        //public DbSet<Package> Packages { get; set; }
        //public DbSet<PackageCultureObject> PackageCultureObjects { get; set; }
        //public DbSet<CultureObject> CultureObjects { get; set; }
        //public DbSet<TrackVisit> TrackVisits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}

