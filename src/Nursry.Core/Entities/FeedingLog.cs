using Nursry.Core.Enums;
using System;

namespace Nursry.Core.Entities
{
    public abstract class FeedingLog : Log
    {
        public DateTimeOffset StartTime { get; set; }
        public FeedingType FeedingType { get; set; }
    }
}
