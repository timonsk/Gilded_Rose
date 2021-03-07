using Gilded_Rose.Constants;
using Gilded_Rose.Interfaces;

namespace Gilded_Rose.Restrictions
{
    public class DefaultQualityRestriction : IQualityRestriction
    {
        public int Comply(int quality)
        {
            if (quality <= ItemConstant.MinimumQualityDegradation)
            {
                return ItemConstant.MinimumQualityDegradation;
            }

            if (quality > ItemConstant.MaximumQualitySize)
            {
                return ItemConstant.MaximumQualitySize;
            }

            return quality;
        }
    }
}
