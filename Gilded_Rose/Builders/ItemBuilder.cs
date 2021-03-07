using Gilded_Rose.Interfaces.Builders;
using Gilded_Rose.Models;

namespace Gilded_Rose
{
    public class ItemBuilder : IItemBuilder
    {
        private readonly IItemFactory _itemFactory;

        public ItemBuilder(IItemFactory itemFactory)
        {
            _itemFactory = itemFactory;
        }

        public Item Build(string name, int sellIn, int quality)
        {
            var item = _itemFactory.Create(name);
            item.SellIn = sellIn;
            item.Quality = quality;

            return item;
        }
    }
}
