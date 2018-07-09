namespace HP.Demo.Domain.DataContracts
{
    public interface IPassword
    {
        byte[] Salt { get; }
        byte[] Hash { get; }
    }
}
