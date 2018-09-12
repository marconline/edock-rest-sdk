using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Orders
{
    public class OrderRow
    {
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public int? DecreasedQuantity { get; set; }
        public double Price { get; set; }
        public string InternalName { get; set; }
        public double? Discount { get; set; }
        public OrderDiscountTypeEnum? DiscountTypeId { get; set; }

        public double RowValue
        {
            get
            {
                double tempTotal = Quantity * Price;

                if (DiscountTypeId.HasValue && Discount.HasValue)
                {
                    switch (DiscountTypeId.Value)
                    {
                        case OrderDiscountTypeEnum.Fixed:
                            tempTotal -= Discount.Value;
                            break;
                        case OrderDiscountTypeEnum.Percentual:
                            tempTotal -= ((tempTotal * Discount.Value) / 100);
                            break;
                    }
                }

                return tempTotal;
            }
        }
    }
}
