namespace HP.Demo.Domain.Contracts
{
    public interface IProjectionBuilder
    {
        TProjection Build<TValue, TProjection>(TValue value);
    }
}
