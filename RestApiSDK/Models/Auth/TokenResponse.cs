using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Models.Auth
{
    public class TokenResponse
    {
        [DeserializeAs(Name = "access_token")]
        public string AccessToken { get; set; }

        [DeserializeAs(Name = "expires_in")]
        public int ExpiresIn { get; set; }

        [DeserializeAs(Name = "token_type")]
        public string TokenType { get; set; }

        [DeserializeAs(Name = "refresh_token")]
        public string RefreshToken { get; set; }
    }
}
