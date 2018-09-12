using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Attributes
{
    public class Attribute
    {
        public int? idAttributeSetAttribute { get; set; }
        public int idAttributeType { get; set; }
        public string Name { get; set; }

        public bool GroupByThisOneBay { get; set; }
        public int Order { get; set; }

        public List<string> Values = new List<string>();
    }
}
