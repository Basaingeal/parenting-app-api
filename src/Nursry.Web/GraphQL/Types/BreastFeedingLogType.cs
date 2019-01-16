using GraphQL.Types;
using Nursry.Core.Entities;
using Nursry.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nursry.Web.GraphQL.Types
{
    public class BreastFeedingLogType : ObjectGraphType<BreastFeedingLog>
    {
        public BreastFeedingLogType(IChildRepository childRepo)
        {
            Name = "BreastFeedingLog";
            Description = "A record of a breast feeding that took place.";

            Field<GuidGraphType>("id", description: "The id of the feeding log", resolve: ctx => ctx.Source.Id);
            Field(l => l.UserId).Description("The user ID of the owner of the log");
            Field(l => l.Details, nullable: true).Description("Additional details from the creator of the log");
            Field<ChildType>(
                "child",
                resolve: ctx => ctx.Source.Child ?? (object)childRepo.GetByIdAsync(ctx.Source.Child.Id),
                description: "The child that was fed.");
            Field<DateTimeGraphType>("startTime",
                resolve: ctx => ctx.Source.StartTime,
                description: "When the feeding started.");
            Field<DateTimeGraphType>("endTime",
                resolve: ctx => ctx.Source.EndTime,
                description: "When the feeding ended.");
            Field<FeedingTypeEnum>("feedingType",
                resolve: ctx => ctx.Source.FeedingType,
                description: "The type of feeding performed.");

            Field<TimeSpanSecondsGraphType>(
                "leftBreastDuration",
                resolve: ctx => ctx.Source.LeftBreastDuration,
                description: "The amount of time fed on the left breast.");

            Field<TimeSpanSecondsGraphType>(
                "rightBreastDuration",
                resolve: ctx => ctx.Source.RightBreastDuration,
                description: "The amount of time fed on the right breast.");

            Field<BreastEnum>("lastBreastUsed",
                resolve: ctx => ctx.Source.LastBreastUsed,
                description: "Which breast was used last in the feeding.");

            Interface<LogInterface>();
        }
    }
}
