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

            Field<GuidGraphType>("id", description: "The ID of the child.", resolve: ctx => ctx.Source.Id);
            Field(c => c.UserId).Description("The user ID of the user who has this child");
            FieldAsync<ListGraphType<LogInterface>>(
                "logs",
                resolve: async ctx =>
                {
                    if (ctx.Source.Logs?.Count > 0)
                    {
                        return ctx.Source.Logs;
                    }
                    LogsByChildId getChildLogsSpec = new LogsByChildId(ctx.Source.Id);
                    return await logRepo.ListAsync(getChildLogsSpec);
                });

            Field<GenderEnum>(
                "gender",
                resolve: ctx => ctx.Source.Gender,
                description: "The gender of the child");
        }
    }
}
