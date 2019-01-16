using GraphQL.Types;
using Nursry.Core.Enums;

namespace Nursry.Web.GraphQL.Types
{
    public class GenderEnum : EnumerationGraphType<Gender>
    {
        public GenderEnum()
        {
            Name = "GenderEnum";
        }
    }
}
