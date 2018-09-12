using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Items
{
    public class ItemCondition
    {
        public ItemConditionValue idItemCondition { get; set; }
    }

    public enum ItemConditionValue
    {
        New = 1,
        NewWithDefects = 2,
        AsNew = 3,
        Used = 4,
        VeryGoodConditions = 5,
        GoodConditions = 6,
        AcceptableConditions = 7,
        RefurbishedByManufacturer = 8,
        RefurbishedByReseller = 9,
        SparePartOrNotWorking = 10,
        NewWithoutLabelOrBox = 11
    }
}
