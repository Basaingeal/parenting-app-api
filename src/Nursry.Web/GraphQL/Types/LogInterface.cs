using GraphQL.Types;
using Nursry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nursry.Web.GraphQL.Types
{
    public class LogInterface : InterfaceGraphType<Log>
    {
        public LogInterface(FeedingLogType flType, BottleFeedingLogType bflType, DiaperLogType dlType)
        {
            Name = "Log";

            Field<GuidGraphType>("id", description: "The id of the log", resolve: ctx => ctx.Source.Id);
            Field(l => l.UserId).Description("The user ID of the owner of the log");
            Field(l => l.Details, nullable: true).Description("Additional details from the creator of the log");
            Field<ChildType>("child");

            ResolveType = obj =>
            {
                if (obj is BottleFeedingLog)
                {
                    return bflType;
                }
                if (obj is FeedingLog)
                {
                    return flType;
                }
                if (obj is DiaperLog)
                {
                    return dlType;
                }
                throw new ArgumentOutOfRangeException($"Could not resolve graph type for {obj.GetType().Name}");
            };
        }
    }
}
