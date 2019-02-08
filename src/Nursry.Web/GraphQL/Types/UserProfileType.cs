using GraphQL.Types;
using Nursry.Core.Entities;
using Nursry.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nursry.Web.GraphQL.Types
{
    public class UserProfileType : ObjectGraphType<UserProfile>
    {
        public UserProfileType()
        {
            Name = "UserProfile";
            Description = "The profile of a user containing their preferences.";
            Field<IdGraphType>("id", description: "The ID of the user profile.", resolve: ctx => ctx.Source.Id);
            Field(c => c.UserId).Description("The user ID of the user profile");
            Field<UnitSystemEnum>(
                "preferredUnitSystem",
                description: "The user's preferred system of measurment.",
                resolve: ctx => ctx.Source.PreferredUnitSystem);
        }
    }
}
