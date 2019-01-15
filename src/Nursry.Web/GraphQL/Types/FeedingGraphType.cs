using GraphQL.Types;
using Nursry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nursry.Web.GraphQL.Types
{
    public class FeedingGraphType : ObjectGraphType<FeedingType>
    {
        public FeedingGraphType()
        {
            Name = "FeedingType";
            Description = "The means by which the feeding took place.";

            Field<GuidGraphType>("id", description: "The id of the feeding type.", resolve: ctx => ctx.Source.Id);
            Field(g => g.Type).Description("The feeding type.");
        }
    }
}
