using GraphQL.Types;
using Nursry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nursry.Web.GraphQL
{
    public class BottleFeedingLogType : FeedingLogType
    {
        public BottleFeedingLogType()
        {
            Field<DecimalGraphType>("amount", resolve: ctx =>
            {
                var source = (BottleFeedingLog)ctx.Source;
                return source.Amount;
            });

            Field<GuidGraphType>("bottleContentId", resolve: ctx =>
            {
                var source = (BottleFeedingLog)ctx.Source;
                return source.Contents.Id;
            });

            Field<StringGraphType>("bottleContents", resolve: ctx =>
            {
                var source = (BottleFeedingLog)ctx.Source;
                return source.Contents.Content;
            });
        }
    }
}
