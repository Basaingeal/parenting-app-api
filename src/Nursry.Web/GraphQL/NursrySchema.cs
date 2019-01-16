using GraphQL;
using GraphQL.Types;
using Nursry.Web.GraphQL.Types;

namespace Nursry.Web.GraphQL
{
    public class NursrySchema : Schema
    {
        public NursrySchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<NursryQuery>();
            Mutation = resolver.Resolve<NursryMutation>();
            RegisterType<BottleFeedingLogType>();
            RegisterType<BreastFeedingLogType>();
            RegisterType<DiaperLogType>();
        }
    }
}
