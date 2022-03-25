using AutoPartsStore.AN.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsStore.DAL.EF
{
    public class ApplicationContext : DbContext
    {
        private string connectionString;

        public DbSet<Brand>? Brands { get; set; }
        public DbSet<Detail>? Details { get; set; }
        public DbSet<Feature>? Features { get; set; }
        public DbSet<Manufacturer>? Manufacturers { get; set; }
        public DbSet<Model>? Models { get; set; }
        public DbSet<Modification>? Modifications { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<PriceList>? PriceLists { get; set; }
        public DbSet<Section>? Sections { get; set; }
        public DbSet<Status>? Statuses { get; set; }
        public DbSet<TypeDetail>? TypeDetails { get; set; }
        public DbSet<TypeTransport>? TypeTransports { get; set; }
        public DbSet<User>? Users { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
