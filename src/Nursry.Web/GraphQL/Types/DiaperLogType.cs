using GraphQL.Types;
using Nursry.Core.Entities;
using Nursry.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nursry.Web.GraphQL.Types
{
    public class DiaperLogType : ObjectGraphType<DiaperLog>
    {
        public DiaperLogType(IChildRepository childRepo)
        {
            Name = "DiaperLog";
            Description = "A record of a diaper change that took place.";

            Field<GuidGraphType>("id", description: "The id of the diaper change log", resolve: ctx => ctx.Source.Id);
            Field(l => l.UserId).Description("The user ID of the owner of the log");
            Field(l => l.Details, nullable: true).Description("Additional details from the creator of the log");
            Field<ChildType>(
                "child",
                resolve: ctx => childRepo.GetByIdAsync(ctx.Source.Child.Id),
                description: "The child that was fed.");
            Field<DateTimeGraphType>("timeOfDiaperChange",
                resolve: ctx => ctx.Source.TimeOfDiaperChange,
                description: "When the diaper change occured.");
            Field<DiaperTypeEnumType>("diaperType",
                resolve: ctx => ctx.Source.DiaperType,
                description: "The type of diaper change performed.");

            Interface<LogInterface>();
        }
    }
}
