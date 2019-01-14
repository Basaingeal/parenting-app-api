using GraphQL.Types;
using Nursry.Core.Interfaces;
using Nursry.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nursry.Web.GraphQL
{
    public class ChildrenQuery : ObjectGraphType
    {
        public ChildrenQuery(IChildRepository childRepository)
        {
            Field<ChildType>(
                "child",
                arguments: new QueryArguments(new QueryArgument<GuidGraphType> { Name = "id" }),
                resolve: context => childRepository.GetByIdAsync(context.GetArgument<Guid>("id")));

            Field<ListGraphType<ChildType>>(
                "children",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "userId" }),
                resolve: context =>
                {
                    var spec = new UserChildrenWithLogsSpecification(context.GetArgument<string>("userId"));
                    return childRepository.ListAsync(spec);
                });
        }
    }
}
