using GraphQL.Types;
using Nursry.Core.Entities;
using Nursry.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nursry.Web.GraphQL.Types
{
    public class BottleFeedingLogType: ObjectGraphType<BottleFeedingLog>
    {
        public BottleFeedingLogType(IChildRepository childRepo)
        {
            Name = "BottleFeedingLog";
            Description = "A record of a bottle feeding that took place.";

            Field<GuidGraphType>("id", description: "The id of the bottle feeding log", resolve: ctx => ctx.Source.Id);
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

            Field<DecimalGraphType>("amount",
                resolve: ctx => ctx.Source.Amount,
                description: "The amount fed in ml.");

            Field<BottleContentsType>("contents",
                resolve: ctx => ctx.Source.Contents,
                description: "The contents of the bottle.");

            Interface<LogInterface>();
        }
    }
}
