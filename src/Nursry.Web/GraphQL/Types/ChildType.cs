using GraphQL.Types;
using Nursry.Core.Entities;
using Nursry.Core.Interfaces;
using Nursry.Core.Specifications;
using System.Linq;

namespace Nursry.Web.GraphQL.Types
{
    public class ChildType : ObjectGraphType<Child>
    {
        public ChildType(ILogRepository logRepo)
        {
            Name = "Child";
            Description = "A child of the user, to whom logs belong.";

            Field<IdGraphType>("id", description: "The ID of the child.", resolve: ctx => ctx.Source.Id);
            Field(c => c.UserId).Description("The user ID of the user who has this child");
            Field(c => c.FirstName);
            Field(c => c.LastName, nullable: true);
            FieldAsync<ListGraphType<LogInterface>>(
                "logs",
                resolve: async ctx =>
                {
                    if (ctx.Source.Logs?.Count > 0)
                    {
                        return ctx.Source.Logs.OrderByDescending(l => l.DateAdded);
                    }
                    LogsByChildId getChildLogsSpec = new LogsByChildId(ctx.Source.Id);
                    return (await logRepo.ListAsync(getChildLogsSpec)).OrderByDescending(l => l.DateAdded);
                });

            Field<DateTimeOffsetGraphType>(
                "dateOfBirth",
                resolve: ctx => ctx.Source.DateOfBirth,
                description: "The birthday and time of the child");

            Field<GenderEnum>(
                "gender",
                resolve: ctx => ctx.Source.Gender,
                description: "The gender of the child");

            Field<DateTimeGraphType>("dateAdded",
                description: "The date the child was added",
                resolve: ctx => ctx.Source.DateAdded);

            Field(c => c.ImageAdded);
        }
    }
}
