using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Tracking
{
    public class TrackingModel
    {
        public Dictionary<string, string> CustomProperties { get; set; } = new Dictionary<string, string>();
    }
}
