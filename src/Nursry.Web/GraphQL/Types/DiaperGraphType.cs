using GraphQL.Types;
using Nursry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nursry.Web.GraphQL.Types
{
    public class DiaperGraphType : ObjectGraphType<DiaperType>
    {
        public DiaperGraphType()
        {
            Name = "DiaperType";
            Description = "The type of diaper changed.";

            Field<GuidGraphType>("id", description: "The id of the diaper type", resolve: ctx => ctx.Source.Id);
            Field(g => g.Title).Description("The diaper type.");
        }
    }
}
