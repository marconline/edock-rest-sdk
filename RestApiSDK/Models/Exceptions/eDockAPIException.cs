using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Exceptions
{
    public class eDockAPIException :  Exception
    {
        public eDockAPIException() { }
        public eDockAPIException(string Message) : base(Message) { }
    }
}
