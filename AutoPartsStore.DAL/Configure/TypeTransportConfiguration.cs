using AutoPartsStore.AN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoPartsStore.DAL.Configure {
    public class TypeTransportConfiguration : IEntityTypeConfiguration<TypeTransport> {
        public void Configure(EntityTypeBuilder<TypeTransport> builder) {
            builder.Property(e => e.Name).IsRequired();
        }
    }
}
