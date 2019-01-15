using GraphQL.Types;
using Nursry.Core.Entities;

namespace Nursry.Web.GraphQL.Types
{
    public class BottleContentsType : ObjectGraphType<BottleContent>
    {
        public BottleContentsType()
        {
            Name = "BottleContent";
            Description = "The contents of the bottle fed";

            Field<GuidGraphType>("id", description: "The id of the bottle content", resolve: ctx => ctx.Source.Id);
            Field(g => g.Content).Description("The bottle content.");
        }
    }
}
