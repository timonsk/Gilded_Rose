using Gilded_Rose.Constants;
using Gilded_Rose.Interfaces;
using Gilded_Rose.Interfaces.Behaviors;
using Gilded_Rose.Models;

namespace Gilded_Rose.Behaviors.Quality
{
    public class AgedBrieUpdateQualityBehavior : IUpdateQualityBehavior
    {
        private readonly IQualityRestriction _qualityRestriction;

        public AgedBrieUpdateQualityBehavior(IQualityRestriction qualityRestriction)
        {
            _qualityRestriction = qualityRestriction;
        }

        public int Execute(Item item)
        {
            var quality = _qualityRestriction.Comply(item.Quality);
            quality += ItemConstant.DefaultIteratorValue;

            return _qualityRestriction.Comply(quality);
        }
    }
}
