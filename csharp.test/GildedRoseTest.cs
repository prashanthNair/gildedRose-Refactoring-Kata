using csharp.Factory;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        { 
            GildedRose app = createGildedRose("foo", 0, 0);
             
            app.UpdateQuality();
            Assert.AreEqual("fixme", app.Items[0].Name);
        }

        [Test]
        public void standardItemDecreasesSellByDayNumberEachTime()
        { 
            GildedRose app = createGildedRose(Constants.STANDARD_ITEM, 0, 0);  
            app.UpdateQuality();

            Assert.AreEqual(-1, itemSellByDayNumber(app));
        }

        [Test]
        public void brieDecreasesSellByDayNumberEachTime()
        { 
            GildedRose app = createGildedRose(Constants.BRIE, 0, 0);
             
            app.UpdateQuality();

            Assert.AreEqual(-1, itemSellByDayNumber(app));
        }

        [Test]
        public void backstagePassesItemDecreasesSellByDayNumberEachTime()
        {
            GildedRose app = createGildedRose(Constants.BACKSTAGE_PASSES_ITEM, 0, 0);

            app.UpdateQuality();

            Assert.AreEqual(-1, itemSellByDayNumber(app));

        }

        [Test]
        public void conjuredItemDecreasesSellByDayNumberEachTime()
        {
            GildedRose app = createGildedRose(Constants.CONJURED_ITEM, 0, 0);

            app.UpdateQuality();

            Assert.AreEqual(-1, itemSellByDayNumber(app));

        }

        [Test]
        public void brieIncreasesInQualityEachTime()
        {
            GildedRose app = createGildedRose(Constants.BRIE, 1, 1);

            app.UpdateQuality();

            Assert.AreEqual(2, itemQualityValue(app));
        }

        [Test]
        public void brieQualityCannotGoAboveFiftyWhenIncreasing()
        {
            GildedRose app = createGildedRose(Constants.BRIE, 1, 49);

            app.UpdateQuality();
            app.UpdateQuality();

            Assert.AreEqual(50, itemQualityValue(app));
        }

        [Test]
        public void backstagePassesItemDecreasesQualityByOneIfSellByDayMoreThanEleven()
        {
            GildedRose app = createGildedRose(Constants.BACKSTAGE_PASSES_ITEM, 12, 1);

            app.UpdateQuality();

            Assert.AreEqual(2, itemQualityValue(app));
        }

        [Test]
        public void backstagePassesItemDecreasesQualityByTwoIfSellByDayIsMoreThanSix()
        {
            GildedRose app = createGildedRose(Constants.BACKSTAGE_PASSES_ITEM, 10, 1);

            app.UpdateQuality();

            Assert.AreEqual(3, itemQualityValue(app));
        }

        public void backstagePassesItemDecreasesQualityByThreeIfSellByDayIsMoreThanZero()
        {
            GildedRose app = createGildedRose(Constants.BACKSTAGE_PASSES_ITEM, 5, 1);

            app.UpdateQuality();

            Assert.AreEqual(4, itemQualityValue(app));
        }

        [Test]
        public void backstagePassesItemQualityDropsToZeroIfSellByDayIsZeroOrLess()
        {
            GildedRose app = createGildedRose(Constants.BACKSTAGE_PASSES_ITEM, 0, 50);

            app.UpdateQuality();

            Assert.AreEqual(0, itemQualityValue(app));
        }

        [Test]
        public void backstagePassesItemQualityCannotGoAboveFiftyWhenIncreasing()
        {
            GildedRose app = createGildedRose(Constants.BACKSTAGE_PASSES_ITEM, 5, 50);

            app.UpdateQuality();

            Assert.AreEqual(50, itemQualityValue(app));
        }

        [Test]
        public void standardItemDecreasesQualityByOneIfSellByDayIsAboveZero()
        {
            GildedRose app = createGildedRose("foo", 2, 1);

            app.UpdateQuality();

            Assert.AreEqual(0, itemQualityValue(app));
        }

        [Test]
        public void standardItemDecreasesQualityByTwoOnceSellByDayIsZeroOrLess()
        {
            GildedRose app = createGildedRose("foo", 0, 5);

            app.UpdateQuality();

            Assert.AreEqual(3, itemQualityValue(app));
        }

        [Test]
        public void standardItemCannotHaveQualityBelowZero()
        {
            GildedRose app = createGildedRose("foo", 0, 0);

            app.UpdateQuality();

            Assert.AreEqual(0, itemQualityValue(app));
        }

        [Test]
        public void sulfurasHasQualityEighty()
        {
            GildedRose app = createGildedRose(Constants.SULFURAS, 1, 80);

            Assert.AreEqual(80, itemQualityValue(app));
        }

        [Test]
        public void sulfurasItemDoesNotAlterValues()
        {
            GildedRose app = createGildedRose(Constants.SULFURAS, 1, 80);

            app.UpdateQuality();

            Assert.AreEqual(80, itemQualityValue(app));
            Assert.AreEqual(1, itemSellByDayNumber(app));
        }

        [Test]
        public void conjuredItemDecreasesQualityByTwoIfSellByDayIsAboveZero()
        {
            GildedRose app = createGildedRose(Constants.CONJURED_ITEM, 2, 5);

            app.UpdateQuality();

            Assert.AreEqual(3, itemQualityValue(app));
        }

        [Test]
        public void conjuredItemDecreasesQualityByFourOnceSellByDayIsZeroOrLess()
        {
            GildedRose app = createGildedRose(Constants.CONJURED_ITEM, 0, 5);

            app.UpdateQuality();

            Assert.AreEqual(1, itemQualityValue(app));
        }

        private GildedRose createGildedRose(String itemName, int itemSellIn, int itemQuality)
        {
            IList<Item> items = new List<Item> { new Item { Name = itemName, SellIn = itemSellIn, Quality = itemQuality } };

            return new GildedRose(items);
        }

        private int itemSellByDayNumber(GildedRose app)
        {
            return app.Items[0].SellIn;
        }

        private int itemQualityValue(GildedRose app)
        {
            return app.Items[0].Quality;
        }
    }
}
