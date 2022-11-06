using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortalStore.Core.Entity;

namespace PortalStore.Data.Configuration
{
    public class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Product).WithMany(x => x.Baskets).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Customer).WithMany(x => x.Baskets).HasForeignKey(x => x.CustomerId);
        }
    }
}
