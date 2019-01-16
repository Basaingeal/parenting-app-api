using Nursry.Core.Entities;

namespace Nursry.Core.Specifications
{
    public class UserChildrenWithLogsSpecification : BaseSpecification<Child>
    {
        public UserChildrenWithLogsSpecification(string userId) : base(c => c.UserId == userId)
        {
            AddInclude(c => c.Logs);
        }
    }
}
