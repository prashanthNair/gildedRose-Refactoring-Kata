using csharp.Factory;
using csharp.Interfaces;
using System;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        public IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        } 

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {
                customisedItem(item).UpdateState();
                if (hasReachedLowestQualityValue(item))
                {
                    item.Quality = Constants.LOWEST_QUALITY_VALUE_POSSIBLE;
                }
                else if (hasReachedHighestQualityValue(item))
                {
                    item.Quality = QualityValues.highestValuePossible(item);
                }
            }
        }

        private IItem customisedItem(Item item)
        {
            return new ItemFactory(item).customiseItem(item);
        }

        private bool hasReachedHighestQualityValue(Item item)
        {
            return item.Quality > QualityValues.highestValuePossible(item);
        }

        private bool hasReachedLowestQualityValue(Item item)
        {
            return item.Quality < Constants.LOWEST_QUALITY_VALUE_POSSIBLE;
        }
    }
}
