using csharp.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    internal class QualityValues
    {
        public static int highestValuePossible(Item item)
        {
            if (item.Name.Equals(Constants.SULFURAS))
            {
                return Constants.SULFURAS_HIGHEST_QUALITY_VALUE_POSSIBLE;
            }
            return Constants.HIGHEST_QUALITY_VALUE_POSSIBLE;
        }
    }
}
