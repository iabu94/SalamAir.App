using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalamAir.Domain.Entities;

namespace SalamAir.Data.Configurations
{
    internal class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Items");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Description);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Active).HasDefaultValue(true);

            builder.HasOne(x => x.SubCategory)
                .WithMany(c => c.Items)
                .HasForeignKey(c => c.SubCategoryId);
        }
    }
}
