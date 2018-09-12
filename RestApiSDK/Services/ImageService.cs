using eDock.Common.RestApiSDK.Models.Credentials;
using eDock.Common.RestApiSDK.Models.Exceptions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Services
{
    public class ImageService : BaseRestService
    {
        public ImageService(eDockCredentials Credentials)
            : base(Credentials)
        {

        }

        public string Upload(string FileName, byte[] RawFile)
        {
            RestRequest req = base.CreateRequest("Images/Upload", RestSharp.Method.POST, new { });
            Client.RemoveDefaultParameter("Content-Type");
            req.AddHeader("Content-Type", "multipart/form-data");
            req.AddFile(FileName, RawFile, FileName);
            IRestResponse<List<string>> resp = Client.Execute<List<string>>(req);

            if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();
            else if (resp.StatusCode != HttpStatusCode.OK)
                throw new eDockAPIException();
            else
            {
                List<string> RespData = resp.Data;
                return RespData.FirstOrDefault();
            }

        }
    }
}
