using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            _ = builder.HasIndex(c => c.Name);

            builder.Property(p => p.Id).HasMaxLength(32);
            builder.Property(p => p.Name).HasMaxLength(32);
            //builder.Property(p => p.Amount).HasMaxLength(20);
            //builder.Property(p => p.TransactionReference).HasMaxLength(100);
            //builder.Property(c => c.PaymentStatus).HasMaxLength(50).HasConversion(new EnumToStringConverter<PaymentStatus>());
            //builder.Property(c => c.PaymentType).HasMaxLength(50).HasConversion(new EnumToStringConverter<PaymentType>());
        }
    }
}
