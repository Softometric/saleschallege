using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Persistence.Configurations
{
    public class SalesOrderConfiguration : IEntityTypeConfiguration<SalesOrder>
    {
        public void Configure(EntityTypeBuilder<SalesOrder> builder)
        {
            _ = builder.HasIndex(c => c.CustomerId);
            _ = builder.HasIndex(c => c.ProductId);

            builder.Property(p => p.Id).HasMaxLength(32);
            builder.Property(p => p.ProductId).HasMaxLength(32);
            builder.Property(p => p.CustomerId).HasMaxLength(32);
            builder.Property(p => p.Quantity).HasMaxLength(20);
            builder.Property(p => p.UnitPrice).HasMaxLength(20);
            builder.Property(c => c.SalesStatus).HasMaxLength(50).HasConversion(new EnumToStringConverter<SalesStatus>());

            
        }
    }
}
