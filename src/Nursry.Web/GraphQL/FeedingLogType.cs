using GraphQL.Types;
using Nursry.Core.Entities;
using Nursry.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nursry.Web.GraphQL
{
    public class FeedingLogType : LogType
    {
        public FeedingLogType()
        {
            Field<DateTimeGraphType>("startTime", resolve: context => {
                var source = (FeedingLog)context.Source;
                return source.StartTime.ToUniversalTime();
                });
            Field<DateTimeGraphType>("endTime", resolve: context => {
                var source = (FeedingLog)context.Source;
                return source.EndTime.ToUniversalTime();
            });
            Field<StringGraphType>("details", resolve: ctx =>
            {
                var source = (FeedingLog)ctx.Source;
                return source.Details;
            });
            Field<GuidGraphType>("feedingTypeId", resolve: context => {
                var source = (FeedingLog)context.Source;
                return source.FeedingType.Id;
            });
            Field<DateGraphType>("feedingType", resolve: context => {
                var source = (FeedingLog)context.Source;
                return source.FeedingType.Type;
            });
        }
    }
}
