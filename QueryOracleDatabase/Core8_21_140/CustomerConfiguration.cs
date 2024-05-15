using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core8_21_140
{
    public class CustomerConfiguration : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            ArgumentNullException.ThrowIfNull(builder);

            builder.ToTable("CUSTOMERS");

            builder.HasKey(k => k.CustomerId);

            builder
                .Property(p => p.CustomerId)
                .HasColumnName("CUSTOMER_ID")
                .IsRequired();
            builder
                .Property(p => p.Name)
                .HasColumnName("NAME")
                .HasColumnType("VARCHAR2")
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
