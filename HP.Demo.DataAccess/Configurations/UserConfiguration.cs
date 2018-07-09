using HP.Demo.Domain.DataContracts;
using HP.Demo.Domain.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HP.Demo.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        private const string TableName = "eUsers";
        private const string RowVersionColumnName = "RowVersion";

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Hash).IsRequired();
            builder.Property(u => u.Salt).IsRequired();
            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(Constraints.EmailMaxLength);
            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property<byte[]>(RowVersionColumnName).IsRowVersion();

            builder.Ignore(u => u.Groups);
        }
    }
}
