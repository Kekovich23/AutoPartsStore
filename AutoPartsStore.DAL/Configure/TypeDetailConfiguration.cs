using AutoPartsStore.AN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoPartsStore.DAL.Configure {
    public class TypeDetailConfiguration : IEntityTypeConfiguration<TypeDetail> {
        public void Configure(EntityTypeBuilder<TypeDetail> builder) {
            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.SectionId).IsRequired();
        }
    }
}
