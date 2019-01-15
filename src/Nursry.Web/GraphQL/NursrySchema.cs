using GraphQL;
using GraphQL.Types;
using Nursry.Web.GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nursry.Web.GraphQL
{
    public class NursrySchema : Schema
    {
        public NursrySchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<NursryQuery>();
            RegisterType<FeedingLogType>();
            RegisterType<DiaperLogType>();
        }
    }
}
