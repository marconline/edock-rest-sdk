using eDock.Common.RestApiSDK.Models.Credentials;
using eDock.Common.RestApiSDK.Models.Exceptions;
using eDock.Common.RestApiSDK.Models.Exports;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Services
{
    public class CustomOrderExportService: BaseRestService
    {
        public CustomOrderExportService(eDockCredentials Credentials)
            : base(Credentials)
        {

        }


        public bool GenerateReportForDS(CustomOrdersExportFilterDTO filter)
        {
            RestRequest elm = CreateRequest<CustomOrdersExportFilterDTO>("CustomOrderExport/GenerateReportForDS", Method.POST, filter);

            var body = elm.Parameters.Where(p => p.Type == ParameterType.RequestBody).FirstOrDefault();
            string req = body.Value.ToString();

            IRestResponse resp = Client.Execute(elm);

            if (resp.StatusCode == HttpStatusCode.OK)
                return true;
            else if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();
            else
                throw new eDockAPIException();
        }
    }
}
