using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Folders
{
    public class Folder
    {
        public int idCategory { get; set; }
        public int idParent { get; set; }
        public string CategoryName { get; set; }
    }
}
