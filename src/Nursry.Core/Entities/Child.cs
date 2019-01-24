using Nursry.Core.Enums;
using Nursry.Core.SharedKernel;
using System;
using System.Collections.Generic;

namespace Nursry.Core.Entities
{
    public class Child : UserOwnedEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public bool ImageAdded { get; set; }
        public ICollection<Log> Logs { get; set; }
    }
}
