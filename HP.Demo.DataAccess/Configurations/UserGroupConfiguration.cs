using HP.Demo.Domain.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HP.Demo.DataAccess.Configurations
{
    public class UserGroupConfiguration : IEntityTypeConfiguration<UserGroup>
    {
        private const string TableName = "xUserGroups";

        public void Configure(EntityTypeBuilder<UserGroup> builder)
        {
            builder.ToTable(TableName);
            builder.HasKey(ug => new { ug.UserId, ug.GroupId });
            builder.HasOne(ug => ug.Group).WithMany();
            builder.HasOne(ug => ug.User).WithMany("UserGroups");
        }
    }
}
