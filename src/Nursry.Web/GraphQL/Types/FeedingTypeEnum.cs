using GraphQL.Types;
using Nursry.Core.Entities;

namespace Nursry.Web.GraphQL.Types
{
    public class FeedingTypeEnum : EnumerationGraphType<FeedingType>
    {
        public FeedingTypeEnum()
        {
            Name = "FeedingTypeEnum";
        }
    }
}
