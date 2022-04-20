using AutoPartsStore.AN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoPartsStore.DAL.Configure {
    public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer> {
        public void Configure(EntityTypeBuilder<Manufacturer> builder) {
            builder.Property(b => b.Name).IsRequired();
        }
    }
}
