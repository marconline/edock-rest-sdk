using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Items
{
    public class ItemIdentifier
    {
        public int idItemIdentifier { get; set; }
        public ItemIdentifierType idIdentifierType { get; set; }
        public string Value { get; set; }
        public int? idModule { get; set; }
        public string SubmoduleName { get; set; }
    }
}
