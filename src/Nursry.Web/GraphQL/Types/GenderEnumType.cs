using GraphQL.Types;
using Nursry.Core.Entities;

namespace Nursry.Web.GraphQL.Types
{
    public class GenderEnumType : EnumerationGraphType<Gender>
    {
        public GenderEnumType()
        {
            Name = "GenderEnum";
        }
    }
}
