using Nursry.Core.Enums;
using System;

namespace Nursry.Core.Entities
{
    public class BreastFeedingLog : FeedingLog
    {
        public TimeSpan LeftBreastDuration { get; set; }
        public TimeSpan RightBreastDuration { get; set; }
        public Breast LastBreastUsed { get; set; }

        public BreastFeedingLog()
        {
            FeedingType = FeedingType.Breast;
        }
    }
}
