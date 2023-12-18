using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Persistence.Configurations
{
    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            _ = builder.HasIndex(c => c.ProductId);
            _ = builder.HasIndex(c => c.ProductId);

            builder.Property(p => p.Id).HasMaxLength(32);
            builder.Property(p => p.ProductId).HasMaxLength(32);
            builder.Property(p => p.Quantity).HasMaxLength(10);
            builder.Property(p => p.CostPrice).HasMaxLength(20);
           
        }
    }
}
