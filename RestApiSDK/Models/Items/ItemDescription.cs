using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Items
{
    public enum ItemDescriptionType
    {
        Name = 1,
        ShortDescription = 2,
        LongDescription = 3
    }

    public class ItemDescription
    {
        public string CultureName { get; set; }
        public ItemDescriptionType DescriptionTypeId { get; set; }
        public string Description { get; set; }
    }
}
