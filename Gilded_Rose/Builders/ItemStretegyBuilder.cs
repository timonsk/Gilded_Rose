using Gilded_Rose.Behaviors.Quality;
using Gilded_Rose.Behaviors.SellIn;
using Gilded_Rose.Interfaces;
using Gilded_Rose.Interfaces.Builders;
using Gilded_Rose.Models;
using Gilded_Rose.Strategies;
using System;

namespace Gilded_Rose.Builders
{
    public class ItemStretegyBuilder : IItemStretegyBuilder
    {
        private readonly IQualityRestrictionBuilder _qualityRestrictionBuilder;
        private readonly IItemBuilder _itemBuilder;

        public ItemStretegyBuilder(
            IQualityRestrictionBuilder qualityRestrictionBuilder,
            IItemBuilder itemBuilder)
        {
            _qualityRestrictionBuilder = qualityRestrictionBuilder;
            _itemBuilder = itemBuilder;
        }

        public IItemStrategy Build(Item item)
        {
            if (!(item is ItemBase))
            {
                item = _itemBuilder.Build(name: item.Name, sellIn: item.SellIn, quality: item.Quality);
            }

            switch (item)
            {
                case RegularItem:
                    return new ItemStrategy(new DefaultUpdateQualityBehavior(_qualityRestrictionBuilder.Build(item)), new DefaultUpdateSellInBehavior());
                case AgedBrie:
                    return new ItemStrategy(new AgedBrieUpdateQualityBehavior(_qualityRestrictionBuilder.Build(item)), new DefaultUpdateSellInBehavior());
                case BackstagePasses:
                    return new ItemStrategy(new BackstagePassesUpdateQualityBehavior(_qualityRestrictionBuilder.Build(item)), new DefaultUpdateSellInBehavior());
                case Sulfuras:
                    return new ItemStrategy(new SulfurasUpdateQualityBehavior(), new SulfurasUpdateSellInBehavior());
                case Conjured:
                    return new ItemStrategy(new ConjuredUpdateQualityBehavior(_qualityRestrictionBuilder.Build(item)), new DefaultUpdateSellInBehavior());
                default: throw new NotImplementedException($"Strategy not define");
            }
        }
    }
}
