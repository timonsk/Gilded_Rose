using Gilded_Rose.Constants;
using Gilded_Rose.Interfaces;
using Gilded_Rose.Interfaces.Behaviors;
using Gilded_Rose.Models;

namespace Gilded_Rose.Behaviors.Quality
{
    public class DefaultUpdateQualityBehavior : IUpdateQualityBehavior
    {
        private readonly IQualityRestriction _qualityRestriction;

        public DefaultUpdateQualityBehavior(IQualityRestriction qualityRestriction)
        {
            _qualityRestriction = qualityRestriction;
        }

        public int Execute(Item item)
        {
            var quality = _qualityRestriction.Comply(item.Quality);

            if (item.SellIn <= ItemConstant.SellInEndDate)
            {
                quality -= ItemConstant.DefaultIteratorValue * ItemConstant.DegradationScale;
            }
            else
            {
                quality -= ItemConstant.DefaultIteratorValue;
            }

            return _qualityRestriction.Comply(quality);
        }
    }
}
