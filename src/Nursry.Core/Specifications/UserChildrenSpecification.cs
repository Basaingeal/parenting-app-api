using Nursry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nursry.Core.Specifications
{
    public class UserChildrenSpecification : BaseSpecification<Child>
    {
        public UserChildrenSpecification(string userId) : base(c => c.UserId == userId)
        {
        }
    }
}
