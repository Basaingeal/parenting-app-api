using GraphQL.Types;
using Nursry.Core.Entities;

namespace Nursry.Web.GraphQL
{
    public class ChildType : ObjectGraphType<Child>
    {
        public ChildType()
        {
            Field<GuidGraphType>("id", resolve: ctx => ctx.Source.Id);
            Field(x => x.UserId);
            Field<StringGraphType>("gender", resolve: ctx => ctx.Source.Gender.Title);
            Field<GuidGraphType>("genderId", resolve: ctx => ctx.Source.Gender.Id);
            Field<ListGraphType<LogType>>("logs",
                arguments: new QueryArguments(new QueryArgument<GuidGraphType> { Name = "id", }),
                resolve: context => context.Source.Logs);
        }
    }
}
