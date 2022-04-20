using AutoPartsStore.AN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoPartsStore.DAL.Configure {
    public class DetailConfiguration : IEntityTypeConfiguration<Detail> {
        public void Configure(EntityTypeBuilder<Detail> builder) {
            builder.Property(d => d.ManufacturerId).IsRequired();
            builder.Property(d => d.TypeDetailId).IsRequired();
        }
    }
}
