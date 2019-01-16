using GraphQL.Types;
using Nursry.Core.Enums;

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
