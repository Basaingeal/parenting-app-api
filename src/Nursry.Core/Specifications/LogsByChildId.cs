using Nursry.Core.Entities;
using System;

namespace Nursry.Core.Specifications
{
    public class LogsByChildId : BaseSpecification<Log>
    {
        public LogsByChildId(Guid childId) : base(c => c.Child.Id == childId)
        {
        }
    }
}
