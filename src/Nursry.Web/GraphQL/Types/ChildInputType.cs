using GraphQL.Types;
using Nursry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nursry.Web.GraphQL.Types
{
    public class ChildInputType : InputObjectGraphType<Child>
    {
        public ChildInputType()
        {
            Name = "ChildInput";
            Field<NonNullGraphType<StringGraphType>>("firstName", resolve: ctx => ctx.Source.FirstName);
            Field<StringGraphType>("lastName", resolve: ctx => ctx.Source.LastName);
            Field<NonNullGraphType<DateTimeOffsetGraphType>>("dateOfBirth", resolve: ctx => ctx.Source.DateOfBirth);
            Field<NonNullGraphType<GenderEnum>>("gender", resolve: ctx => ctx.Source.Gender);
            Field<BooleanGraphType>("imageAdded", resolve: ctx => ctx.Source.ImageAdded);
        }
    }
}
