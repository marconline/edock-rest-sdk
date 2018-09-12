using eDock.Common.RestApiSDK.Models.Credentials;
using eDock.Common.RestApiSDK.Models.Exceptions;
using eDock.Common.RestApiSDK.Models.Folders;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Services
{
    public class FolderService : BaseRestService
    {
        public FolderService(eDockCredentials Credentials)
            : base(Credentials)
        {

        }

        public FolderContainerResponse GetRootFolders()
        {
            RestRequest elm = CreateGetRequest("Folders");
            IRestResponse<FolderContainerResponse> resp = Client.Execute<FolderContainerResponse>(elm);

            if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();
            else if (resp.StatusCode != HttpStatusCode.OK)
            {
                throw new eDockAPIException();
            }

            return resp.Data;
        }

        public FolderContainerResponse GetChildren(int idFolder = 1)
        {
            RestRequest elm = CreateGetRequest("Folders");
            elm.AddParameter("idFolder", idFolder, ParameterType.QueryString);
            elm.AddParameter("loadAll", false, ParameterType.QueryString);

            IRestResponse<FolderContainerResponse> resp = Client.Execute<FolderContainerResponse>(elm);

            if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();
            else if (resp.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new eDockAPIException();
            }

            return resp.Data;
        }

        public FolderContainerResponse GetHierarcy(int idFolder = 1)
        {
            RestRequest elm = CreateGetRequest("Folders/GetHierarchy");
            elm.AddParameter("idFolder", idFolder, ParameterType.QueryString);

            IRestResponse<FolderContainerResponse> resp = Client.Execute<FolderContainerResponse>(elm);

            if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();
            else if (resp.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new eDockAPIException();
            }

            return resp.Data;
        }

        public Folder Create(FolderCreate Folder)
        {
            RestRequest elm = CreateRequest<FolderCreate>("Folders/Create", Method.POST, Folder);
            IRestResponse<Folder> resp = Client.Execute<Folder>(elm);

            if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();
            else if (resp.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new eDockAPIException();
            }

            return resp.Data;
        }
    }
}
