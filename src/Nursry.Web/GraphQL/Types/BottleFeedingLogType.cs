using GraphQL.Types;
using Nursry.Core.Entities;
using Nursry.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nursry.Web.GraphQL.Types
{
    public class BottleFeedingLogType : ObjectGraphType<BottleFeedingLog>
    {
        public BottleFeedingLogType(IChildRepository childRepo)
        {
            Name = "BottleFeedingLog";
            Description = "A record of a bottle feeding that took place.";

            Field<IdGraphType>("id", description: "The id of the bottle feeding log", resolve: ctx => ctx.Source.Id);
            Field(l => l.UserId).Description("The user ID of the owner of the log");
            Field(l => l.Details, nullable: true).Description("Additional details from the creator of the log");
            Field<ChildType>(
                "child",
                resolve: ctx => ctx.Source.Child ?? (object)childRepo.GetByIdAsync(ctx.Source.ChildId),
                description: "The child that was fed.");
            Field<DateTimeOffsetGraphType>("startTime",
                resolve: ctx => ctx.Source.StartTime,
                description: "When the feeding started.");

            Field<FeedingTypeEnum>("feedingType",
                resolve: ctx => ctx.Source.FeedingType,
                description: "The type of feeding performed.");

            Field<DecimalGraphType>(
                "amount",
                resolve: ctx => ctx.Source.Amount,
                description: "The amount fed in ml for bottle feedings");

            Field<BottleContentEnum>("bottleContent",
                resolve: ctx => ctx.Source.Contents,
                description: "What was fed in the bottle.");

            Field<DateTimeGraphType>("dateAdded",
                description: "The date the bottle feeding log was added",
                resolve: ctx => ctx.Source.DateAdded);

            Interface<LogInterface>();
        }
    }
}
