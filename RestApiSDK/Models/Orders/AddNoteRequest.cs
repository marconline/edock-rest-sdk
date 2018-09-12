using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Orders
{
    public class AddNoteRequest
    {
        public int idOrder { get; set; }
        public string Notes { get; set; }
    }
}
