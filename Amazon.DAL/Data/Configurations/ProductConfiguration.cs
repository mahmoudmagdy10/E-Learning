using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Amazon.DAL.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.RatingsAverage).HasColumnType("decimal(18,2)");

            builder.HasOne(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .HasPrincipalKey(p => p.Id);

            builder.HasOne(p => p.Brand)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.BrandId)
                    .HasPrincipalKey(p => p.Id);
            
            builder.HasMany(p => p.Images)
                    .WithOne(c => c.Products)
                    .HasForeignKey(p => p.ProductId)
                    .HasPrincipalKey(p => p.Id);
        }
    }
}
