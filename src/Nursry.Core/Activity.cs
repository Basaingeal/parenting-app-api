using Nursry.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nursry.Core
{
    public class Activity : BaseEntity
    {
        public string Name { get; set; }
        public DateTime TimeStarted { get; set; }
        public DateTime TimeEnded { get; set; }
    }
}
