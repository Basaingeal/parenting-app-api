using GraphQL.Types;
using Nursry.Core.Entities;
using Nursry.Core.Enums;
using Nursry.Core.Interfaces;
using Nursry.Core.Specifications;
using Nursry.Web.GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Nursry.Web.GraphQL
{
    public class NursryQuery : ObjectGraphType<object>
    {
        public NursryQuery(IChildRepository childRepo)
        {
            Name = "Query";

            Field<ListGraphType<GenderEnum>>(
                "genders",
                resolve: _ => Enum.GetValues(typeof(Gender)).Cast<Gender>()
                );

            Field<ListGraphType<FeedingTypeEnum>>(
                "feedingTypes",
                resolve: _ => Enum.GetValues(typeof(FeedingType)).Cast<FeedingType>()
                );

            FieldAsync<ListGraphType<ChildType>>(
                "children",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "childId"}
                    ),
                resolve: async ctx =>
                {
                    ClaimsPrincipal user = ctx.UserContext as ClaimsPrincipal;
                    string userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;
                    UserChildrenSpecification childrenByUserId = new UserChildrenSpecification(userId);
                    Guid childId = ctx.GetArgument<Guid>("childId");
                    if(childId != Guid.Empty)
                    {
                        var child = await childRepo.GetByIdAsync(childId);
                        if(child.UserId != userId)
                        {
                            return new List<Child>();
                        }
                        return new List<Child> { child };
                    }
                    return await childRepo.ListAsync(childrenByUserId);
                }
                );
            FieldAsync<ChildType>(
                "child",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
                    ),
                resolve: async ctx =>
                {
                    ClaimsPrincipal user = ctx.UserContext as ClaimsPrincipal;
                    string userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;
                    Guid childId = ctx.GetArgument<Guid>("id");
                    var child = await childRepo.GetByIdAsync(childId);
                    if(child.UserId != userId)
                    {
                        return null;
                    }
                    return child;
                }
                );
        }
    }
}
