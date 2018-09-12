using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Folders
{
    public class FolderCreate
    {
        public string CategoryName { get; set; }
        public int idParent { get; set; }
    }
}
