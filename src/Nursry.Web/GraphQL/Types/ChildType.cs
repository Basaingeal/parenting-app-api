using GraphQL.Types;
using Nursry.Core.Entities;
using Nursry.Core.Interfaces;
using Nursry.Core.Specifications;

namespace Nursry.Web.GraphQL.Types
{
    public class ChildType : ObjectGraphType<Child>
    {
        public ChildType(ILogRepository logRepo)
        {
            Name = "Child";
            Description = "A child of the user, to whom logs belong.";

            Field(c => c.Id).Description("The ID of the child.");
            Field(c => c.UserId).Description("The user ID of the user who has this child");
            Field<ListGraphType<LogInterface>>(
                "logs",
                resolve: ctx =>
                {
                    LogsByChildId getChildLogsSpec = new LogsByChildId(ctx.Source.Id);
                    return logRepo.ListAsync(getChildLogsSpec);
                });

            Field<GenderType>("gender", resolve: ctx => ctx.Source.Gender, description: "The gender of the child");
        }
    }
}
