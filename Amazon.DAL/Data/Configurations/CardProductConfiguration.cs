using Amazon.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Reflection.Emit;

namespace Amazon.DAL.Data.Configurations
{
    public class CartProductConfiguration : IEntityTypeConfiguration<CartProduct>
    {
        public void Configure(EntityTypeBuilder<CartProduct> builder)
        {
            //builder.HasKey(cp => new { cp.CartId, cp.Product.Id });

            //builder.HasOne(cp => cp.Cart)
            //    .WithMany(c => c.CartProducts)
            //    .HasForeignKey(cp => cp.CartId);

            //builder.HasMany(cp => cp.Product)
            //    .WithMany(p => p.CartProducts)
            //    .HasForeignKey(cp => cp.ProductId);
        }
    }
}
