using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Domain.Enums;

namespace Infrastructure.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            _ = builder.HasIndex(c => c.PhoneNo);
            _ = builder.HasIndex(c => c.Email);

            builder.Property(p => p.Id).HasMaxLength(32);
            builder.Property(p => p.Email).HasMaxLength(20);
            builder.Property(p => p.PhoneNo).HasMaxLength(20);
            builder.Property(p => p.LastName).HasMaxLength(100);
            builder.Property(p => p.FirstName).HasMaxLength(100);
            builder.Property(p => p.Gender).HasMaxLength(20).HasConversion(new EnumToStringConverter<Sex >());
            builder.OwnsOne(x => x.CustomerAddress)
                .Property(x => x.Country).HasColumnName("Country").HasMaxLength(100);  
            builder.OwnsOne(x => x.CustomerAddress)
                .Property(x => x.City).HasColumnName("City").HasMaxLength(100);
            builder.OwnsOne(x => x.CustomerAddress)
                .Property(x => x.Street).HasColumnName("Street").HasMaxLength(100);
            builder.OwnsOne(x => x.CustomerAddress)
                .Property(x => x.ZipCode).HasColumnName("ZipCode").HasMaxLength(100);
        }
    }
}
