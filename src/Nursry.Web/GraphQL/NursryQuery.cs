using GraphQL.Types;
using Nursry.Core.Entities;
using Nursry.Core.Interfaces;
using Nursry.Web.GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nursry.Web.GraphQL
{
    public class NursryQuery : ObjectGraphType<object>
    {
        public NursryQuery(IAsyncRepository<Gender> genderRepo)
        {
            Name = "Query";

            Field<ListGraphType<GenderType>>(
                "genders",
                resolve: _ => genderRepo.ListAllAsync()
                );
        }
    }
}
