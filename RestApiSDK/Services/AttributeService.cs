using eDock.Common.RestApiSDK.Models.Attributes;
using eDock.Common.RestApiSDK.Models.Credentials;
using eDock.Common.RestApiSDK.Models.Exceptions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Services
{
    public class AttributeService : BaseRestService
    {
        public AttributeService(eDockCredentials Credentials)
            : base(Credentials)
        {

        }

        public List<AttributeSet> Get()
        {
            RestRequest elm = CreateGetRequest("Attributes");
            elm.AddParameter("GetSets", true, ParameterType.QueryString);

            IRestResponse<List<AttributeSet>> resp = Client.Execute<List<AttributeSet>>(elm);

            if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();
            else if (resp.StatusCode != HttpStatusCode.OK)
            {
                throw new eDockAPIException();
            }

            return resp.Data;
        }

        public AttributeSet Get(int idAttributeSet)
        {
            RestRequest elm = CreateGetRequest("Attributes");
            elm.AddParameter("id", idAttributeSet, ParameterType.QueryString);
            elm.AddParameter("isSetId", true, ParameterType.QueryString);

            IRestResponse<AttributeSet> resp = Client.Execute<AttributeSet>(elm);
            if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();
            else if (resp.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new eDockAPIException();
            }

            return resp.Data;
        }

        //public AttributeSet Create(AttributeSet AttributeSet)
        //{
        //    RestRequest elm = CreateRequest<AttributeSet>("Attributes", Method.POST, AttributeSet);

        //    IRestResponse<int> resp = Client.Execute<int>(elm);
        //    if (resp.StatusCode != System.Net.HttpStatusCode.OK)
        //    {
        //        throw new eDockAPIException();
        //    }

        //    int idAttributeSet = resp.Data;
        //    return Get(idAttributeSet);

        //}
    }
}
