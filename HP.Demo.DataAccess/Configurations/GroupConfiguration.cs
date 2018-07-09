using HP.Demo.Domain.DataContracts;
using HP.Demo.Domain.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HP.Demo.DataAccess.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        private const string TableName = "eGroups";

        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(g => g.Id);
            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(Constraints.GroupNameMaxLength);
            builder.HasIndex(u => u.Name).IsUnique();
        }
    }
}
