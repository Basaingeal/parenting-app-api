namespace Nursry.Core.Entities
{
    public class BottleFeedingLog : FeedingLog
    {
        /// <summary>
        /// Stores the amount of content in ml
        /// </summary>
        public decimal Amount { get; set; }
        public BottleContent Contents { get; set; }

        public BottleFeedingLog()
        {
            FeedingType = FeedingType.Bottle;
        }
    }
}
