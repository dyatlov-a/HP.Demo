namespace HP.Demo.Domain.Models.Identity.Specifications
{
    public class GroupIsDefaultSpec : GroupByTypeSpec
    {
        public GroupIsDefaultSpec() : base(GroupType.Default)
        {
        }
    }
}
