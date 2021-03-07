using Gilded_Rose.Interfaces;
using Gilded_Rose.Interfaces.Builders;
using Gilded_Rose.Models;
using Gilded_Rose.Restrictions;
using System;

namespace Gilded_Rose.Builders
{
    public class QualityRestrictionBuilder : IQualityRestrictionBuilder
    {
        public IQualityRestriction Build(Item item)
        {
            switch (item)
            {
                case RegularItem:
                case AgedBrie:
                case BackstagePasses:
                case Conjured:
                    return new DefaultQualityRestriction();
                default: throw new NotImplementedException($"Strategy not define for type {item?.GetType()}");
            }
        }
    }
}
