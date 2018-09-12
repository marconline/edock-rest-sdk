using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Orders
{
    public class OrderAddress
    {
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string CountyAbbreviation { get; set; }
        public string CountryAbbreviation { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string VATCode { get; set; }
    }
}
