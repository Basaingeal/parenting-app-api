using GraphQL.Types;
using Nursry.Core.Entities;
using Nursry.Core.Interfaces;
using Nursry.Core.Specifications;
using Nursry.Web.GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                    var userContext = ctx.UserContext as GraphQLUserContext;
                    var childrenByUserId = new UserChildrenWithLogsSpecification(userContext.User.Identity.Name);
                    return childRepo.ListAsync(childrenByUserId);
                }
                );
        }
    }
}
