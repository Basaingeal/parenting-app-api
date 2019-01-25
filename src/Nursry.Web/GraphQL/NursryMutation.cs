using GraphQL.Types;
using Nursry.Core.Entities;
using Nursry.Core.Enums;
using Nursry.Core.Interfaces;
using Nursry.Web.GraphQL.Types;
using System.Security.Claims;

namespace Nursry.Web.GraphQL
{
    public class NursryMutation : ObjectGraphType
    {
        public NursryMutation(IChildRepository childRepo, ILogRepository logRepo)
        {
            Name = "Mutation";

            Field<ChildType>(
                "createChild",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ChildInputType>> { Name = "child" }
                    ),
                resolve: ctx =>
                {
                    var user = ctx.UserContext as ClaimsPrincipal;
                    Child child = ctx.GetArgument<Child>("child");
                    child.UserId = user.FindFirst(ClaimTypes.NameIdentifier).Value;
                    return childRepo.AddAsync(child);
                });

            Field<BreastFeedingLogType>(
                "createBreastFeedingLog",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<BreastFeedingLogInputType>> { Name = "log" }
                    ),
                resolve: ctx =>
                {
                    var user = ctx.UserContext as ClaimsPrincipal;
                    BreastFeedingLog log = ctx.GetArgument<BreastFeedingLog>("log");
                    log.UserId = user.FindFirst(ClaimTypes.NameIdentifier).Value;
                    return logRepo.AddAsync(log);
                });
        }
    }
}
