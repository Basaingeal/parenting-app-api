using GraphQL.Types;
using Nursry.Core.Entities;
using System;

namespace Nursry.Web.GraphQL.Types
{
    public class BreastFeedingLogInputType : InputObjectGraphType<BreastFeedingLog>
    {
        public BreastFeedingLogInputType()
        {
            Name = "BreastFeedingLogInput";
            Field<StringGraphType>("details", resolve: ctx => ctx.Source.Details);
            Field<NonNullGraphType<IdGraphType>>("childId", resolve: ctx => ctx.Source.ChildId);
            Field<NonNullGraphType<DateTimeOffsetGraphType>>("startTime", resolve: ctx => ctx.Source.StartTime);
            Field<NonNullGraphType<DateTimeOffsetGraphType>>("endTime", resolve: ctx => ctx.Source.EndTime);
            Field<NonNullGraphType<MyTimeSpanSecondsGraphType>>("leftBreastDuration", resolve: ctx => ctx.Source.LeftBreastDuration);
            Field<NonNullGraphType<MyTimeSpanSecondsGraphType>>("rightBreastDuration", resolve: ctx => ctx.Source.RightBreastDuration);
            Field<NonNullGraphType<BreastEnum>>("lastBreastUsed", resolve: ctx => ctx.Source.LastBreastUsed);
        }
    }
}
