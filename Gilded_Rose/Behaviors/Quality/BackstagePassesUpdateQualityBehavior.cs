using Gilded_Rose.Constants;
using Gilded_Rose.Interfaces;
using Gilded_Rose.Interfaces.Behaviors;
using Gilded_Rose.Models;

namespace Gilded_Rose.Behaviors.Quality
{
    public class BackstagePassesUpdateQualityBehavior : IUpdateQualityBehavior
    {
        public const int BeforMaxSellInDays = 10;
        public const int BeforMinSellInDays = 5;

        public const int MinQualityValue = 0;

        private readonly IQualityRestriction _qualityRestriction;

        public BackstagePassesUpdateQualityBehavior(IQualityRestriction qualityRestriction)
        {
            _qualityRestriction = qualityRestriction;
        }

        public int Execute(Item item)
        {
            var quality = _qualityRestriction.Comply(item.Quality);

            if (item.SellIn > BeforMinSellInDays && item.SellIn < BeforMaxSellInDays)
            {
                quality += 3;
            }

            if (item.SellIn > ItemConstant.SellInEndDate
                && item.SellIn < BeforMinSellInDays)
            {
                quality += 2;
            }
            else
            {
                quality += ItemConstant.DefaultIteratorValue;
            }

            if (item.SellIn < ItemConstant.SellInEndDate)
            {
                quality = MinQualityValue;
            }

            return _qualityRestriction.Comply(quality);
        }
    }
}
