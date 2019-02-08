using GraphQL.Types;
using Nursry.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nursry.Web.GraphQL.Types
{
    public class UnitSystemEnum : EnumerationGraphType<UnitSystem>
    {
        public UnitSystemEnum()
        {
            Name = "UnitSystemEnum";
        }
    }
}
