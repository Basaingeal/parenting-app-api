using GraphQL.Types;
using Nursry.Core.Entities;

namespace Nursry.Web.GraphQL.Types
{
    public class FeedingTypeEnumType : EnumerationGraphType<FeedingType>
    {
        public FeedingTypeEnumType()
        {
            Name = "FeedingTypeEnum";
        }
    }
}
