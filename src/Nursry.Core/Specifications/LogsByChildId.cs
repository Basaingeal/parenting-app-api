using Nursry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Nursry.Core.Specifications
{
    public class LogsByChildId : BaseSpecification<Log>
    {
        public LogsByChildId(Guid childId) : base(c => c.Child.Id == childId)
        {
            AddInclude($"{nameof(Child.Logs)}.{nameof(FeedingType)}");
            AddInclude($"{nameof(Child.Logs)}.{nameof(DiaperType)}");
            AddInclude($"{nameof(Child.Logs)}.{nameof(BottleContent)}");
        }
    }
}
