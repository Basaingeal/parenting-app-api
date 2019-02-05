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

            FieldAsync<BreastFeedingLogType>(
                "updateBreastFeedingLog",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<BreastFeedingLogInputType>> { Name = "log" }
                    ),
                resolve: async ctx =>
                {
                    var user = ctx.UserContext as ClaimsPrincipal;
                    BreastFeedingLog inputLog = ctx.GetArgument<BreastFeedingLog>("log");
                    if(inputLog.Id == default(System.Guid))
                    {
                        return null;
                    }
                    BreastFeedingLog logFromRepo = (BreastFeedingLog)(await logRepo.GetByIdAsync(inputLog.Id));
                    string userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;
                    if (userId != logFromRepo.UserId)
                    {
                        return null;
                    }
                    logFromRepo.ChildId = inputLog.ChildId;
                    logFromRepo.Details = inputLog.Details;
                    logFromRepo.LastBreastUsed = inputLog.LastBreastUsed;
                    logFromRepo.LeftBreastDuration = inputLog.LeftBreastDuration;
                    logFromRepo.RightBreastDuration = inputLog.RightBreastDuration;
                    logFromRepo.StartTime = inputLog.StartTime;
                    return logRepo.UpdateAsync(logFromRepo);
                });
        }
    }
}
