using System;
using System.Collections.Generic;
using System.Text;

namespace Nursry.Core.Entities
{
    public class DiaperLog : Log
    {
        public DateTime TimeOfDiaperChange { get; set; }
        public DiaperType DiaperType { get; set; }
    }
}
