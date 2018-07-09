using System;
using HP.Demo.DataAccess.Configurations;
using HP.Demo.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace HP.Demo.DataAccess.Contexts
{
    public class UserContext : DbContext
    {
        private readonly IDataInit _dataInit;

        public UserContext(DbContextOptions<UserContext> options, IDataInit dataInit)
            : base(options)
        {
            _dataInit = dataInit ?? throw new ArgumentNullException(nameof(dataInit));
        }

        public override int SaveChanges()
        {
            if (!ChangeTracker.HasChanges())
                return 0;

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserGroupConfiguration());

            _dataInit.Seed(modelBuilder);
        }
    }
}
