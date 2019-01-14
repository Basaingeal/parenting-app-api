using GraphQL.Types;
using Nursry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nursry.Web.GraphQL
{
    public abstract class LogType : ObjectGraphType<Log>
    {
        public LogType()
        {
            Field<GuidGraphType>("id", resolve: ctx => ctx.Source.Id);
            Field(x => x.UserId);
            Field<ChildType>("child", resolve: ctx => ctx.Source.Child);
        }
    }
}
