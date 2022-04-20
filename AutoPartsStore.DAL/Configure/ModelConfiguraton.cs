using AutoPartsStore.AN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoPartsStore.DAL.Configure {
    public class ModelConfiguraton : IEntityTypeConfiguration<Model> {
        public void Configure(EntityTypeBuilder<Model> builder) {
            builder.Property(m => m.Name).IsRequired();
            builder.Property(m => m.TypeTransportId).IsRequired();
            builder.Property(m => m.BrandId).IsRequired();
        }
    }
}
