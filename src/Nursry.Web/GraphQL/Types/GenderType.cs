using GraphQL.Types;
using Nursry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nursry.Web.GraphQL.Types
{
    public class GenderType : ObjectGraphType<Gender>
    {
        public GenderType()
        {
            Name = "Gender";
            Description = "The gender of a child.";

            Field<GuidGraphType>("id", description: "The id of the gender", resolve: ctx => ctx.Source.Id);
            Field(g => g.Title).Description("The gender.");
        }
    }
}
