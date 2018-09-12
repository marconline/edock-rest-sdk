﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models
{
    public class PagedResponse<T> where T : new()
    {
        public int PageSize { get; set; }
        public int Page { get; set; }
        public int TotalCount { get; set; }
        public List<T> Content { get; set; }

        public bool HasMore
        {
            get
            {
                return TotalCount > PageSize * (Page + 1);
            }
        }
    }
}
