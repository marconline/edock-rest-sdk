using eDock.Common.RestApiSDK.Models;
using eDock.Common.RestApiSDK.Models.Credentials;
using eDock.Common.RestApiSDK.Models.Exceptions;
using eDock.Common.RestApiSDK.Models.Modules;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Services
{
    public class ModuleService : BaseRestService
    {
        public ModuleService(eDockCredentials Credentials) 
            : base(Credentials)
        {

        }

        public async Task<List<InstalledModule>> GetInstalledModules()
        {
            RestRequest elm = CreateGetRequest("Modules/GetModules");
            IRestResponse<PagedResponse<InstalledModule>> resp = await Client.ExecuteGetTaskAsync<PagedResponse<InstalledModule>>(elm);

            if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();
            else if (resp.StatusCode != HttpStatusCode.OK)
            {
                throw new eDockAPIException();
            }

            return resp.Data.Content;
        }


        public async Task<List<Module>> GetAllModules()
        {
            RestRequest elm = CreateGetRequest("Modules/SellingModules");
            IRestResponse<List<Module>> resp = await Client.ExecuteGetTaskAsync<List<Module>>(elm);

            if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();
            else if (resp.StatusCode != HttpStatusCode.OK)
            {
                throw new eDockAPIException();
            }

            return resp.Data;
        }
    }
}
