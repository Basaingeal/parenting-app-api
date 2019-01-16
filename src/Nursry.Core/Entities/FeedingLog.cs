using System;

namespace Nursry.Core.Entities
{
    public abstract class FeedingLog : Log
    {
        public DateTime StartTime { get; set; }
        public FeedingType FeedingType { get; set; }
    }
}
