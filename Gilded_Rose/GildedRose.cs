using Gilded_Rose.Interfaces;
using Gilded_Rose.Models;
using System;
using System.Collections.Generic;

namespace Gilded_Rose
{
    public class GildedRose
    {
        // Would be nice to refactor as its public field breaks the encapsulation principle, 
        // but because it one of the constraints so, leave it as is.
        IList<Item> Items;

        private readonly IItemStrategyFacade _itemStrategyFacade;

        public GildedRose(IList<Item> Items, IItemStrategyFacade itemStrategyFacade)
        {
            this.Items = Items;
            _itemStrategyFacade = itemStrategyFacade;
        }

        public void Run()
        {
            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                PrintOut();
                UpdateQuality();
            }
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Items[i] = _itemStrategyFacade.UpdateItem(Items[i]);
            }
        }

        public void PrintOut()
        {
            Console.WriteLine("name, sellIn, quality");
            for (var j = 0; j < Items.Count; j++)
            {
                Console.WriteLine(Items[j]);
            }
            Console.WriteLine();
        }
    }
}
