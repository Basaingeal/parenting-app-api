using System;
using System.Collections.Generic;
using System.Text;

namespace Nursry.Core.SharedKernel
{
    public abstract class UserOwnedEntity : BaseEntity
    {
        public string UserId { get; set; }
    }
}
