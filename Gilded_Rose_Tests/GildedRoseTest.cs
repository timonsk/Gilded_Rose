using Gilded_Rose;
using Gilded_Rose.Builders;
using Gilded_Rose.Interfaces;
using Gilded_Rose.Models;
using Gilded_Rose.Strategies;
using NUnit.Framework;
using System.Collections.Generic;

namespace Gilded_Rose_Tests
{
    [TestFixture]
    public class GildedRoseTest
    {
        private IItemStrategyFacade _itemStrategyFacade;

        [SetUp]
        public void Init()
        {
            var qualityRestrictionBuilder = new QualityRestrictionBuilder();
            var itemFactory = new ItemFactory();
            var itemBuilder = new ItemBuilder(itemFactory);
            var itemStretegyBuilder = new ItemStretegyBuilder(qualityRestrictionBuilder, itemBuilder);
            _itemStrategyFacade = new ItemStrategyFacade(itemStretegyBuilder);
        }

        [Test]
        public void NameShouldNotBeChangedAfterIterations()
        {
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(items, _itemStrategyFacade);

            app.UpdateQuality();
            Assert.AreEqual("foo", items[0].Name);

            app.UpdateQuality();
            Assert.AreEqual("foo", items[0].Name);
        }

        [Test]
        public void RegularItemQualityShouldNormallyDegraded()
        {
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 2, Quality = 2 } };
            GildedRose app = new GildedRose(items, _itemStrategyFacade);

            app.UpdateQuality();
            Assert.AreEqual(1, items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void RegularItemQualityShouldDegradedTwiceAsFastAfterSellIn()
        {
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 1, Quality = 5 } };
            GildedRose app = new GildedRose(items, _itemStrategyFacade);

            app.UpdateQuality();
            Assert.AreEqual(4, items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(2, items[0].Quality);

            app.UpdateQuality();
            Assert.AreEqual(0, items[0].Quality);
        }

        [Test]
        public void RegularItemQualityShouldNotBeNegative()
        {
            IList<Item> items = new List<Item> {
                new Item { Name = "foo", SellIn = 1, Quality = 1 },
                new Item { Name = "foo2", SellIn = 1, Quality = -1 }
            };
            GildedRose app = new GildedRose(items, _itemStrategyFacade);

            app.UpdateQuality();
            Assert.AreEqual(0, items[0].Quality);
            Assert.AreEqual(0, items[1].Quality);

            app.UpdateQuality();
            Assert.AreEqual(0, items[0].Quality);
            Assert.AreEqual(0, items[1].Quality);

            app.UpdateQuality();
            Assert.AreEqual(0, items[0].Quality);
            Assert.AreEqual(0, items[1].Quality);
        }
        
        [Test]
        public void RegularItemQualityShouldNotBeHigherThenMaxAllowed()
        {
            IList<Item> items = new List<Item> {
                new Item { Name = "foo", SellIn = 1, Quality = 52 },
                new Item { Name = "Aged Brie", SellIn = 1, Quality = 49 },
                new Item { Name = "Aged Brie", SellIn = 1, Quality = 50 }
            };
            GildedRose app = new GildedRose(items, _itemStrategyFacade);

            app.UpdateQuality();
            Assert.AreEqual(49, items[0].Quality);
            Assert.AreEqual(50, items[1].Quality);
            Assert.AreEqual(50, items[2].Quality);

            app.UpdateQuality();
            Assert.AreEqual(47, items[0].Quality);
            Assert.AreEqual(50, items[1].Quality);
            Assert.AreEqual(50, items[2].Quality);

            app.UpdateQuality();
            Assert.AreEqual(45, items[0].Quality);
            Assert.AreEqual(50, items[1].Quality);
        }
        [Test]
        public void AgedBrieItemShouldIncreaseQualityEachDay()
        {
            IList<Item> items = new List<Item> {
                new Item { Name = "foo", SellIn = 1, Quality = 3 },
                new Item { Name = "Aged Brie", SellIn = 1, Quality = -1 }
            };
            GildedRose app = new GildedRose(items, _itemStrategyFacade);

            app.UpdateQuality();
            Assert.AreEqual(2, items[0].Quality);
            Assert.AreEqual(1, items[1].Quality);

            app.UpdateQuality();
            Assert.AreEqual(0, items[0].Quality);
            Assert.AreEqual(2, items[1].Quality);

            app.UpdateQuality();
            Assert.AreEqual(0, items[0].Quality);
            Assert.AreEqual(3, items[1].Quality);
        }
    }
}
