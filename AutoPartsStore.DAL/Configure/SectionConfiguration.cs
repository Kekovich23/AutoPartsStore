using AutoPartsStore.AN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoPartsStore.DAL.Configure {
    internal class SectionConfiguration : IEntityTypeConfiguration<Section> {
        public void Configure(EntityTypeBuilder<Section> builder) {
            builder.Property(s => s.Name).IsRequired();
        }
    }
}
