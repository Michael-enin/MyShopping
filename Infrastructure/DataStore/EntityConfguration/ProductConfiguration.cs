using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities;
namespace Infrastructure.DataStore.EntityConfguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
            builder.HasOne(x => x.ProductBrand)
                   .WithMany()
                   .HasForeignKey(x => x.ProductBrandId);
            builder.HasOne(x => x.ProductType)
                   .WithMany()
                   .HasForeignKey(x => x.ProductTypeId);

        }
    }
}