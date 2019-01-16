using Nursry.Core.SharedKernel;
using System;

namespace Nursry.Core.Entities
{
    public abstract class Log : UserOwnedEntity
    {
        public Guid ChildId { get; set; }
        public Child Child { get; set; }
        public string Details { get; set; }
    }
}
