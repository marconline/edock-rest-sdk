using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models
{
    public class Sort
    {
        [JsonProperty(PropertyName = "field")]
        public string Field { get; set; }

        [JsonProperty(PropertyName = "verb")]
        public string Verb { get; set; }
    }
}
