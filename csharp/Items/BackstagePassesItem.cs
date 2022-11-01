using csharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.Items
{
    internal class BackstagePassesItem : IItem
    {
        private Item item;

        public BackstagePassesItem(Item item)
        {
            this.item = item;
        }

        public void UpdateState()
        {
            DecreaseSellByDayValueByOne();
            if (SellByDayValueIsOver(10))
            {
                IncreaseQualityBy(1);
            }
            else if (SellByDayValueIsOver(5))
            {
                IncreaseQualityBy(2);
            }
            else if (SellByDayValueIsOver(0))
            {
                IncreaseQualityBy(3);
            }
            else
            {
                DropQualityToZero();
            }
        }

        private void DecreaseSellByDayValueByOne()
        {
            item.SellIn -= 1;
        }

        private bool SellByDayValueIsOver(int dayNumber)
        {
            return item.SellIn > dayNumber;
        }

        private void IncreaseQualityBy(int qualityValue)
        {
            item.Quality += qualityValue;
        }

        private void DropQualityToZero()
        {
            item.Quality = 0;
        }
    }
}
