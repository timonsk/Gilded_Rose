using Gilded_Rose.Interfaces;
using Gilded_Rose.Interfaces.Builders;
using Gilded_Rose.Models;

namespace Gilded_Rose.Strategies
{
    public class ItemStrategyFacade : IItemStrategyFacade
    {
        private readonly IItemStretegyBuilder _itemStretegyBuilder;

        public ItemStrategyFacade(IItemStretegyBuilder itemStretegyBuilder)
        {
            _itemStretegyBuilder = itemStretegyBuilder;
        }

        public Item UpdateItem(Item item)
        {
            var itemStretegy = _itemStretegyBuilder.Build(item);

            item.Quality = itemStretegy.UpdateQuility(item);
            item.SellIn = itemStretegy.UpdateSellIn(item);

            return item;
        }
    }
}
