using GraphQL.Types;
using Nursry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
