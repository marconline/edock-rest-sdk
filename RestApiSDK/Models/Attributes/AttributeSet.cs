using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Attributes
{
    public class AttributeSet
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? idAttributeSet { get; set; }
        
        public string CultureName { get; set; }
        public string Name { get; set; }


        public List<Attribute> Attributes { get; set; }
    }
}
