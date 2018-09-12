using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Modules
{
    public class InstalledModule
    {
        public string AbsoluteSharedRootUri { get; set; }
        public string ApplicationPath { get; set; }
        public string Description { get; set; }
        public int idModule { get; set; }
        public DateTime InstalledOn { get; set; }
        public string PhysicalSharedRootPath { get; set; }
        public string RootPath { get; set; }
        public string SettingPath { get; set; }
        public int? PricelistId { get; set; }

       
    }
}
