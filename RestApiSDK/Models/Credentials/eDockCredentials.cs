using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Credentials
{
    public class eDockCredentials
    {
        public eDockCredentials(string AuthToken)
        {
            this.AuthToken = AuthToken;
        }

        public string AuthToken { get; private set; }
    }
}
