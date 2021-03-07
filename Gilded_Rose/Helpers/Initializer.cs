using Gilded_Rose.Interfaces.Builders;
using Gilded_Rose.Models;
using System.Collections.Generic;

namespace Gilded_Rose.Helpers
{
    public static class ItemsInitializer
    {
        public static IList<Item> SetupStore(IItemBuilder itemBuilder)
        {
            return new List<Item>{
                new Item {       Name = "+7 Dexterity Est",                             SellIn = 15, Quality = 15},
                itemBuilder.Build(name: "+5 Dexterity Vest",                            sellIn: 10, quality: 20),
                itemBuilder.Build(name: "Aged Brie",                                    sellIn: 2,  quality: 0),
                itemBuilder.Build(name: "Elixir of the Mongoose",                       sellIn: 5,  quality: 7),
                itemBuilder.Build(name: "Sulfuras, Hand of Ragnaros",                   sellIn: 0,  quality: 80),
                itemBuilder.Build(name: "Sulfuras, Hand of Ragnaros",                   sellIn: -1, quality: 80),
                itemBuilder.Build(name: "Backstage passes to a TAFKAL80ETC concert",    sellIn: 15, quality: 20),
                itemBuilder.Build(name: "Backstage passes to a TAFKAL80ETC concert",    sellIn: 10, quality: 49),
                itemBuilder.Build(name: "Backstage passes to a TAFKAL80ETC concert",    sellIn: 5,  quality: 49),
                itemBuilder.Build(name: "Conjured Mana Cake",                           sellIn: 3,  quality: 6),
            };
        }
    }
}
