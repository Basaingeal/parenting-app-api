using GraphQL.Types;
using Nursry.Core.Enums;

namespace Nursry.Web.GraphQL.Types
{
    public class DiaperTypeEnumType : EnumerationGraphType<DiaperType>
    {
        public DiaperTypeEnumType()
        {
            Name = "DiaperTypeEnum";
        }
    }
}
