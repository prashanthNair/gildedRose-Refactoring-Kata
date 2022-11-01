using csharp.Interfaces;
using csharp.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.Factory
{
    public class ItemFactory
    {
        private static Dictionary<string, IItem> ITEM_TYPES_LIST;
        public ItemFactory(Item item)
        {
            ITEM_TYPES_LIST = new Dictionary<string, IItem>();
            ITEM_TYPES_LIST.Add(Constants.BRIE, new AgedBrie(item));
            ITEM_TYPES_LIST.Add(Constants.BACKSTAGE_PASSES_ITEM, new BackstagePassesItem(item));
            ITEM_TYPES_LIST.Add(Constants.CONJURED_ITEM, new ConjuredItem(item));
            ITEM_TYPES_LIST.Add(Constants.SULFURAS, new Sulfuras());
        }

        public IItem customiseItem(Item item)
        {
            if (isStandardItem(item))
            {
                return new StandardItem(item);
            }
            return ITEM_TYPES_LIST[item.Name];
        }

        private bool isStandardItem(Item item)
        {
            return !ITEM_TYPES_LIST.ContainsKey(item.Name);
        }
    }
}
