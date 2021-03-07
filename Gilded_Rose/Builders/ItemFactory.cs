using Gilded_Rose.Constants;
using Gilded_Rose.Interfaces.Builders;
using Gilded_Rose.Models;
using System;

namespace Gilded_Rose.Builders
{

    public class ItemFactory : IItemFactory
    {
        public Item Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException($"Item name could not be null or empty");
            }

            if (name.StartsWith(ItemNameConstant.AgedBrie))
            {
                return new AgedBrie(name);
            }

            if (name.StartsWith(ItemNameConstant.Sulfuras))
            {
                return new Sulfuras(name);
            }

            if (name.StartsWith(ItemNameConstant.BackstagePasses))
            {
                return new BackstagePasses(name);
            }

            if (name.StartsWith(ItemNameConstant.Conjured))
            {
                return new Conjured(name);
            }

            return new RegularItem(name);
        }
    }
}
