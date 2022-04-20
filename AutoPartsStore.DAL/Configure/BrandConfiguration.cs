using AutoPartsStore.AN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoPartsStore.DAL.Configure {
    public class BrandConfiguration : IEntityTypeConfiguration<Brand> {
        public void Configure(EntityTypeBuilder<Brand> builder) {
            builder.Property(b => b.Name).IsRequired();
        }
    }
}
