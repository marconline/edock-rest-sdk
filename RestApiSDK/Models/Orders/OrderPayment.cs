using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Orders
{
    public class OrderPayment
    {
        public int Status { get; set; }
        public DateTime PaymentTime { get; set; }
        public decimal PaymentAmount { get; set; }
        public string PaymentAmountCurrency { get; set; }
        public decimal FeeOrCreditAmount { get; set; }
        public string FeeOrCreditAmountCurrency { get; set; }
        public string ExternalTransactionReferenceID { get; set; }
    }
}
