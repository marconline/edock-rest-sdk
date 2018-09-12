using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Orders
{
    public static class PaymentMethodEnum
    {
        public static readonly string PayPalStandard = "PayPal Standard";
        public static readonly string BankTransfer = "Bonifico Bancario";
        public static readonly string Cash = "Contanti";
        public static readonly string BankCheque = "Assegno";
        public static readonly string COD = "Contrassegno";
        public static readonly string PayPalDirect = "PayPal Direct";
        public static readonly string Other = "Altro";
        public static readonly string CreditCard = "Standard CreditCard";
    }
}
