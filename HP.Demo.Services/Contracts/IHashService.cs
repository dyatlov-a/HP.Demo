using HP.Demo.Domain.DataContracts;

namespace HP.Demo.Services.Contracts
{
    public interface IHashService
    {
        IPassword Hash(string plainPassword);
        bool Compare(IPassword hashedPassword, string plainPassword);
    }
}
