using AutoPartsStore.AN.Entities;
using AutoPartsStore.DAL.Configure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsStore.DAL.Context {
    public class ApplicationContext : IdentityDbContext<User> {
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
        public DbSet<Customer>? Customers { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BrandConfiguration());
        }
    }
}
