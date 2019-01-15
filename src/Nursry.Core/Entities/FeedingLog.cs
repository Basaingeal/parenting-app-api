using System;

namespace Nursry.Core.Entities
{
    public class FeedingLog : Log
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public FeedingType FeedingType { get; set; }
        /// <summary>
        /// Stores the amount of content in ml
        /// </summary>
        public decimal? Amount { get; set; }
        public BottleContent? Contents { get; set; }
    }
}
