using GraphQL.Types;
using Nursry.Core.Entities;
using Nursry.Core.Enums;
using Nursry.Core.Interfaces;
using Nursry.Core.Specifications;
using Nursry.Web.GraphQL.Types;
using System;
using System.Security.Claims;

namespace Nursry.Web.GraphQL
{
    public class NursryMutation : ObjectGraphType
    {
        public NursryMutation(IChildRepository childRepo, ILogRepository logRepo, IAsyncRepository<UserProfile> userProfileRepo)
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
                    return await logRepo.UpdateAsync(logFromRepo);
                });

            FieldAsync<IdGraphType>(
                "deleteLog",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "logId" }
                    ),
                resolve: async ctx =>
                {
                    var user = ctx.UserContext as ClaimsPrincipal;
                    Guid logId = ctx.GetArgument<Guid>("logId");
                    string userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;
                    Log logFromRepo = await logRepo.GetByIdAsync(logId);
                    if (userId != logFromRepo.UserId)
                    {
                        return null;
                    }
                    await logRepo.DeleteAsync(logFromRepo);
                    return logId;
                });

            FieldAsync<UserProfileType>(
                "createUserProfile",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserProfileInputType>> { Name = "userProfile" }
                    ),
                resolve: async ctx =>
                {
                    var user = ctx.UserContext as ClaimsPrincipal;
                    UserProfile userProfileInput = ctx.GetArgument<UserProfile>("userProfile");
                    userProfileInput.UserId = user.FindFirst(ClaimTypes.NameIdentifier).Value;
                    UserProfileByUserIdSpecification spec = new UserProfileByUserIdSpecification(userProfileInput.UserId);
                    var existingUserProfiles = await userProfileRepo.ListAsync(spec);
                    if(existingUserProfiles.Count > 0)
                    {
                        return existingUserProfiles[0];
                    }
                    await userProfileRepo.AddAsync(userProfileInput);
                    return userProfileInput;
                });

            FieldAsync<UserProfileType>(
                "updateUserProfile",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserProfileInputType>> { Name = "userProfile" }
                    ),
                resolve: async ctx =>
                {
                    var user = ctx.UserContext as ClaimsPrincipal;
                    UserProfile userProfileInput = ctx.GetArgument<UserProfile>("userProfile");
                    userProfileInput.UserId = user.FindFirst(ClaimTypes.NameIdentifier).Value;
                    UserProfileByUserIdSpecification spec = new UserProfileByUserIdSpecification(userProfileInput.UserId);
                    var existingUserProfiles = await userProfileRepo.ListAsync(spec);
                    if (existingUserProfiles.Count == 0 || existingUserProfiles[0].Id != userProfileInput.Id)
                    {
                        return null;
                    }
                    var profileFromRepo = existingUserProfiles[0];

                    profileFromRepo.PreferredUnitSystem = userProfileInput.PreferredUnitSystem;

                    return await userProfileRepo.UpdateAsync(profileFromRepo);
                });
        }
    }
}
