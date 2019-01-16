using GraphQL.Types;
using Nursry.Core.Enums;

namespace Nursry.Web.GraphQL.Types
{
    public class BottleContentEnum : EnumerationGraphType<BottleContent>
    {
        public BottleContentEnum()
        {
            Name = "BottleContentEnum";
        }
    }
}
