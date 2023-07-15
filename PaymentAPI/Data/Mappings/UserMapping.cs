using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentAPI.Models;

namespace PaymentAPI.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //tabela
            builder.ToTable("User");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.UserName)
                .IsRequired()
                .HasColumnName("UserName")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(99);

            builder.Property(x => x.Password)
                .IsRequired()
                .HasColumnName("Password")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.PhoneNumber)
                .IsRequired(false)
                .HasColumnName("PhoneNumber");
        }
    }
}
