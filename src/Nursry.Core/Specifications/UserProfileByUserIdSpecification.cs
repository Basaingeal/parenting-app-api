using Nursry.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nursry.Core.Specifications
{
    public class UserProfileByUserIdSpecification : BaseSpecification<UserProfile>
    {
        public UserProfileByUserIdSpecification(string userId) : base(up => up.UserId == userId)
        {

        }
    }
}
