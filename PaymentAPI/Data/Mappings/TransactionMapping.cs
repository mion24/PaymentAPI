using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentAPI.Models;

namespace PaymentAPI.Data.Mappings
{
    public class TransactionMapping : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transaction");

            builder.HasKey(t => t.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.DocValue)
                .IsRequired()
                .HasColumnName("DocValue")
                .HasColumnType("DECIMAL");

            builder.Property(x => x.IdReceiver)
                .IsRequired()
                .HasColumnName("IdReceiver")
                .HasColumnType("Int");

            builder.Property(x => x.SenderId)
                .IsRequired()
                .HasColumnName("SenderId")
                .HasColumnType("Int");

            builder.Property(x => x.Doc)
                .IsRequired()
                .HasColumnName("Doc")
                .HasColumnType("VARCHAR");

            builder.HasOne(x => x.Sender)
               .WithMany(x => x.Payments);

        }
    }
}
