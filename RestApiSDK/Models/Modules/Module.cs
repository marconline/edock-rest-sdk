using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Modules
{
    public class Module
    {
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public int? idPricelist { get; set; }
    }
}
