using GraphQL.Types;
using Nursry.Core.Entities;

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
