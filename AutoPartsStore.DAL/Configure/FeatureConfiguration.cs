using AutoPartsStore.AN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoPartsStore.DAL.Configure {
    public class FeatureConfiguration : IEntityTypeConfiguration<Feature> {
        public void Configure(EntityTypeBuilder<Feature> builder) {
            builder.Property(f => f.Name).IsRequired();
        }
    }
}
