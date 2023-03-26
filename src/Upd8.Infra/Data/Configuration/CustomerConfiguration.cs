using Upd8.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Upd8.Infra.Data.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customer");

        builder.HasKey(customer => customer.Id);
        builder.Property(customer => customer.Name);
        builder.Property(customer => customer.Document);
        builder.Property(customer => customer.BirthDate);
        builder.Property(customer => customer.Gender).HasConversion<string>();

        builder.OwnsOne(customer => customer.Address, addressBuilder =>
        {
            addressBuilder.Property(address => address.StreetName).HasColumnName(nameof(Customer.Address.StreetName));
            addressBuilder.Property(address => address.City).HasColumnName(nameof(Customer.Address.City));
            addressBuilder.Property(address => address.State).HasColumnName(nameof(Customer.Address.State));
            addressBuilder.Property(address => address.Country).HasColumnName(nameof(Customer.Address.Country));
        });
    }
}
