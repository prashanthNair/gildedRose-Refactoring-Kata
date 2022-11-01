using csharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    internal class AgedBrie : IItem
    {
        private Item item;

        public AgedBrie(Item item)
        {
            this.item = item;
        }

        public void UpdateState()
        {
            DecreaseSellByDayValueByOne();
            IncreaseQualityByOne();
        }

        private void DecreaseSellByDayValueByOne()
        {
            item.SellIn -= 1;
        }

        private void IncreaseQualityByOne()
        {
            item.Quality += 1;
        }
    }
}
