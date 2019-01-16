using GraphQL.Types;
using Nursry.Core.Entities;
using Nursry.Core.Interfaces;
using Nursry.Web.GraphQL.Types;
using System.Security.Claims;

namespace Nursry.Web.GraphQL
{
    public class NursryMutation : ObjectGraphType
    {
        public NursryMutation(IChildRepository childRepo)
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
        }
    }
}
