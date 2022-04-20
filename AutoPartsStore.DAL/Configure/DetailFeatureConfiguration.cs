using AutoPartsStore.AN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoPartsStore.DAL.Configure {
    public class DetailFeatureConfiguration : IEntityTypeConfiguration<DetailFeature> {
        public void Configure(EntityTypeBuilder<DetailFeature> builder) {
            builder.Property(e => e.FeatureId).IsRequired();
            builder.Property(e => e.DetailId).IsRequired();
            builder.Property(e => e.Value).IsRequired();
        }
    }
}
