using Nursry.Core.Enums;
using Nursry.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Nursry.Core.Entities
{
    public class UserProfile : UserOwnedEntity
    {
        public UnitSystem PreferredUnitSystem { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
