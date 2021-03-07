using Gilded_Rose.Builders;
using Gilded_Rose.Helpers;
using Gilded_Rose.Strategies;
using System;

namespace Gilded_Rose
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var qualityRestrictionBuilder = new QualityRestrictionBuilder();
            var itemFactory = new ItemFactory();
            var itemBuilder = new ItemBuilder(itemFactory);
            var itemStretegyBuilder = new ItemStretegyBuilder(qualityRestrictionBuilder, itemBuilder);
            var itemStrategyFacade = new ItemStrategyFacade(itemStretegyBuilder);

            var app = new GildedRose(ItemsInitializer.SetupStore(itemBuilder), itemStrategyFacade);
            app.Run();

            Console.WriteLine("Press enter key to close the application");
            Console.ReadLine();
        }
    }
}
