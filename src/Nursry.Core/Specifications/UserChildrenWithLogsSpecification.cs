using Nursry.Core.Entities;

namespace Nursry.Core.Specifications
{
    public class UserChildrenWithLogsSpecification : BaseSpecification<Child>
    {
        public UserChildrenWithLogsSpecification(string userId) : base(c => c.UserId == userId)
        {
            AddInclude(c => c.Logs);
            AddInclude(nameof(Child.Gender));
            AddInclude($"{nameof(Child.Logs)}.{nameof(FeedingType)}");
            AddInclude($"{nameof(Child.Logs)}.{nameof(DiaperType)}");
            AddInclude($"{nameof(Child.Logs)}.{nameof(BottleContent)}");
        }
    }
}
