using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Pricelists
{
    public class PriceListModule
    {
        public int idModule { get; set; }
        public string Description { get; set; }
        public List<string> SubModules { get; set; }
    }
}
