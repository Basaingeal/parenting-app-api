using Nursry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nursry.Core.Specifications
{
    class UserChildrenWithGenderSpecification : BaseSpecification<Child>
    {
        public UserChildrenWithGenderSpecification(string userId) : base(c => c.UserId == userId)
        {
            AddInclude(c => c.Logs);
            AddInclude(nameof(Child.Gender));
        }
    }
}
