using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentAPI.Models;

namespace PaymentAPI.Data.Mappings
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Balance)
                .HasColumnName("Balance")
                .HasColumnType("Float")
                .IsRequired()
                .HasDefaultValue(0);

            builder.Property(x => x.CreatedAt)
                .HasColumnName("CreatedAt")
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
