using Nursry.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nursry.Core.Entities
{
    public abstract class Log : UserOwnedEntity
    {
        public Child Child { get; set; }
        public string Details { get; set; }
    }
}
