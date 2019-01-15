using System;
using System.Collections.Generic;
using System.Text;

namespace Nursry.Core.Entities
{
    public class FeedingLog : Log
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public FeedingType FeedingType { get; set; }
    }
}
