using csharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.Items
{
    public class StandardItem : IItem
    {
        private Item item;

        public StandardItem(Item item)
        {
            this.item = item;
        }

        public void UpdateState()
        {
            DecreaseSellByDayValueByOne();
            if (SellByDayValueIsOverZero())
            {
                DecreaseQualityBy(DecreasingValueOverZeroDaysToSell());
            }
            else
            {
                DecreaseQualityBy(DecreasingValueForZeroOrLessDaysToSell());
            }
        }

        public virtual int DecreasingValueOverZeroDaysToSell()
        {
            return 1;
        }

        private void DecreaseSellByDayValueByOne()
        {
            item.SellIn -= 1;
        }

        private bool SellByDayValueIsOverZero()
        {
            return item.SellIn > 0;
        }

        private void DecreaseQualityBy(int qualityValue)
        {
            item.Quality -= qualityValue;
        }

        private int DecreasingValueForZeroOrLessDaysToSell()
        {
            return DecreasingValueOverZeroDaysToSell() * 2;
        }
    }
}
