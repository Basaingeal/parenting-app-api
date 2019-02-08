using GraphQL.Types;
using Nursry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nursry.Web.GraphQL.Types
{
    public class UserProfileInputType : InputObjectGraphType<UserProfile>
    {
        public UserProfileInputType()
        {
            Name = "UserProfileInput";
            Field<IdGraphType>("id", resolve: ctx => ctx.Source.Id);
            Field<NonNullGraphType<UnitSystemEnum>>("preferredUnitSystem", resolve: ctx => ctx.Source.PreferredUnitSystem);
        }
    }
}
