using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Exports
{
    public class CustomOrdersExportFilterDTO
    {
        public int? StatusId { get; set; }
        public int? ModuleId { get; set; }
        public bool OnlyPaid { get; set; }
    }
}
