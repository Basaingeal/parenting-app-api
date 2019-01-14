using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nursry.Web.GraphQL
{
    public class ChildrenSchema : Schema
    {
        public ChildrenSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<ChildrenQuery>();
        }
    }
}
