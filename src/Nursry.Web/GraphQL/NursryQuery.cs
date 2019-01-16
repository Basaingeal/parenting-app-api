using GraphQL.Types;
using Nursry.Core.Enums;
using Nursry.Core.Interfaces;
using Nursry.Core.Specifications;
using Nursry.Web.GraphQL.Types;
using System;
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

            Field<ListGraphType<ChildType>>(
                "children",
                resolve: ctx =>
                {
                    ClaimsPrincipal user = ctx.UserContext as ClaimsPrincipal;
                    string userId = user.FindFirst(ClaimTypes.NameIdentifier).Value;
                    UserChildrenWithLogsSpecification childrenByUserId = new UserChildrenWithLogsSpecification(userId);
                    return childRepo.ListAsync(childrenByUserId);
                }
                );
        }
    }
}
