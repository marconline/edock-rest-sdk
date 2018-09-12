using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models
{
    public class RequestFilter
    {
        public string field { get; set; }
        public List<string> values { get; set; }
    }
}
