using Nursry.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nursry.Core.Entities
{
    public class Child : UserOwnedEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string ImageUri { get; set; }
        public ICollection<Log> Logs { get; set; }
    }
}
