using GraphQL.Types;
using Nursry.Core.Enums;

namespace Nursry.Web.GraphQL.Types
{
    public class BreastEnum : EnumerationGraphType<Breast>
    {
        public BreastEnum()
        {
            Name = "BreastEnum";
        }
    }
}
