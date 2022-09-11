using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalamAir.Domain.Entities;

namespace SalamAir.Data.Configurations
{
    internal class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Active).HasDefaultValue(true);

            builder.HasOne(x => x.Item).WithMany(x => x.Carts);
            builder.HasMany(x => x.Options).WithMany(x => x.Carts);
        }
    }
}
