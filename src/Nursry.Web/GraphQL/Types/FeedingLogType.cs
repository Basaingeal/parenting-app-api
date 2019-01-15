using GraphQL.Types;
using Nursry.Core.Entities;
using Nursry.Core.Interfaces;

namespace Nursry.Web.GraphQL.Types
{
    public class FeedingLogType : ObjectGraphType<FeedingLog>
    {
        public FeedingLogType(IChildRepository childRepo)
        {
            Name = "FeedingLog";
            Description = "A record of a feeding that took place.";

            Field<GuidGraphType>("id", description: "The id of the feeding log", resolve: ctx => ctx.Source.Id);
            Field(l => l.UserId).Description("The user ID of the owner of the log");
            Field(l => l.Details, nullable: true).Description("Additional details from the creator of the log");
            Field<ChildType>(
                "child",
                resolve: ctx => childRepo.GetByIdAsync(ctx.Source.Child.Id),
                description: "The child that was fed.");
            Field<DateTimeGraphType>("startTime",
                resolve: ctx => ctx.Source.StartTime,
                description: "When the feeding started.");
            Field<DateTimeGraphType>("endTime",
                resolve: ctx => ctx.Source.EndTime,
                description: "When the feeding ended.");
            Field<FeedingGraphType>("feedingType",
                resolve: ctx => ctx.Source.FeedingType,
                description: "The type of feeding performed.");

            Interface<LogInterface>();
        }
    }
}
