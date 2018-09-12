using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Items
{
    public class ItemImage
    {
        public int idItemImage { get; set; }
        public string ImagesPath { get; set; }
        public DateTime ImagesCreatedOn { get; set; }
        public bool ImagesIsLocallyHosted { get; set; }
        public int OrderIndex { get; set; }
        public string FullImagePath { get; set; }
        public bool IsDynamicBox { get; set; }
    }
}
