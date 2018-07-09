using Microsoft.EntityFrameworkCore;

namespace HP.Demo.DataAccess.Data
{
    public interface IDataInit
    {
        void Seed(ModelBuilder modelBuilder);
    }
}
