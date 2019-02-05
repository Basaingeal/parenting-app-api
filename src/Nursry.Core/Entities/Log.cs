using Nursry.Core.SharedKernel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nursry.Core.Entities
{
    public abstract class Log : UserOwnedEntity
    {
        public Guid ChildId { get; set; }
        public Child Child { get; set; }
        public string Details { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
