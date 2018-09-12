using eDock.Common.RestApiSDK.Models;
using eDock.Common.RestApiSDK.Models.Credentials;
using eDock.Common.RestApiSDK.Models.Exceptions;
using eDock.Common.RestApiSDK.Models.Items;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace eDock.Common.RestApiSDK.Services
{
    public class ItemService : BaseRestService
    {
        public ItemService(eDockCredentials Credentials)
            : base(Credentials)
        {

        }

        public Item Get(string SKU, List<string> Details, bool IncludeVariations = false, bool ApplyFiltersToVariations = false)
        {
            GetItemsRequest req = new GetItemsRequest()
            {
                Page = 0,
                PageSize = 1,
                filters = new List<RequestFilter>() {
                    new RequestFilter() {
                        field = "ProductSKU",
                        values = new List<string>() { SKU }
                    }
                },
                ApplyFiltersToVariations = ApplyFiltersToVariations,
                IncludeVariations = IncludeVariations
            };

            if (Details != null)
            {
                req.details = new List<ItemDetail>();
                Details.ForEach(x => req.details.Add(new ItemDetail() { field = x }));
            }

            RestRequest elm = CreateRequest<GetItemsRequest>("Products/GetProducts", Method.POST, req);
            IRestResponse<PagedResponse<Item>> resp = Client.Execute<PagedResponse<Item>>(elm);

            if (resp.StatusCode == HttpStatusCode.OK)
            {
                if (resp.Data != null && resp.Data.TotalCount > 0)
                {
                    return resp.Data.Content[0];
                }
                else
                {
                    return null;
                }
            }
            else if (resp.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException();
            }
            else
            {
                return null;
            }
        }

        public bool Create(Item myItem)
        {
            RestRequest elm = CreateRequest<Item>("Products/Create", Method.POST, myItem);

            var body = elm.Parameters.Where(p => p.Type == ParameterType.RequestBody).FirstOrDefault();
            string req = body.Value.ToString();

            IRestResponse resp = Client.Execute(elm);

            if (resp.StatusCode == HttpStatusCode.OK)
                return true;
            else if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();
            else
                throw new eDockAPIException(resp.Content);
        }

        public bool Update(Item myItem)
        {
            RestRequest elm = CreateRequest<Item>("Products/Update", Method.PUT, myItem);
            IRestResponse resp = Client.Execute(elm);

            if (resp.StatusCode == HttpStatusCode.OK)
                return true;
            else if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();
            else
                throw new eDockAPIException();
        }

        public async Task<PagedResponse<Item>> GetInPricelist(int idPricelist, DateTime? LastUpdateDate, List<ItemDetailType> Details, int Page = 0, int PageSize = 50)
        {
            return await Search(new ItemSearchFilter() { idPricing = idPricelist, LastUpdateDate = LastUpdateDate }, Details, Page, PageSize);
        }

        public async Task<bool> UpsertPrice(string SKU, PricingRow Price)
        {
            SKU = HttpUtility.UrlEncode(SKU);
            RestRequest elm = CreateRequest("Products/{SKU}/Prices", Method.POST, Price);
            elm.AddParameter("SKU", SKU, ParameterType.UrlSegment);

            IRestResponse resp = await Client.ExecutePostTaskAsync(elm);
            if (resp.StatusCode == HttpStatusCode.OK || resp.StatusCode == HttpStatusCode.NoContent)
                return true;
            else if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();
            else
                throw new eDockAPIException();
        }

        public async Task<bool> UpsertPrice(string SKU, PricingRowUpdate Update)
        {
            SKU = HttpUtility.UrlEncode(SKU);
            Item itm = Get(SKU, null);
            if (Update == null) throw new eDockAPIException();
            if (itm == null) throw new eDockAPIException();

            PricingRowUpdateInternal rowInternal = new Models.Items.PricingRowUpdateInternal()
            {
                idItem = itm.IdItem.Value,
                Discount = Update.Discount,
                DiscountType = Update.DiscountType,
                ExpectedCurrentPrice = Update.ExpectedCurrentPrice,
                idPricelist = Update.idPricelist,
                Price = Update.Price
            };

            RestRequest elm = CreateRequest<PricingRowUpdate>("PricelistRow/Put", Method.PUT, rowInternal);

            IRestResponse resp = await Client.ExecuteTaskAsync(elm);
            if (resp.StatusCode == HttpStatusCode.OK || resp.StatusCode == HttpStatusCode.NoContent)
                return true;
            else if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();
            else
                throw new eDockAPIException();
        }

        public async Task RemovePrice(string SKU, int PricingId)
        {
            SKU = HttpUtility.UrlEncode(SKU);

            var body = new { PriceListIdPricing = PricingId };
            RestRequest elm = CreateRequest("Products/{SKU}/Prices", Method.DELETE, body);
            elm.AddParameter("SKU", SKU, ParameterType.UrlSegment);

            IRestResponse resp = await Client.ExecutePostTaskAsync(elm);

            if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();
        }

        public async Task<List<PricingRow>> GetPrices(string SKU)
        {
            SKU = HttpUtility.UrlEncode(SKU);

            RestRequest elm = CreateGetRequest("Products/{SKU}/Prices");
            elm.AddParameter("SKU", SKU, ParameterType.UrlSegment);

            IRestResponse<List<PricingRow>> resp = await Client.ExecuteTaskAsync<List<PricingRow>>(elm);

            if (resp.StatusCode == HttpStatusCode.OK)
            {
                return resp.Data;
            }
            else if (resp.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException();
            }
            else
            {
                return null;
            }
        }

        public async Task<PricingRow> GetPrice(string SKU, int PricingId)
        {
            SKU = HttpUtility.UrlEncode(SKU);

            RestRequest elm = CreateGetRequest("Products/{SKU}/Prices/{PricingId}");
            elm.AddParameter("SKU", SKU, ParameterType.UrlSegment);
            elm.AddParameter("PricingId", PricingId, ParameterType.UrlSegment);

            IRestResponse<PricingRow> resp = await Client.ExecuteTaskAsync<PricingRow>(elm);

            if (resp.StatusCode == HttpStatusCode.OK)
            {
                return resp.Data;
            }
            else if (resp.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException();
            }
            else
            {
                return null;
            }
        }

        public async Task<PagedResponse<Item>> Search(ItemSearchFilter Filter, List<ItemDetailType> Details, int Page = 0, int PageSize = 50)
        {
            List<RequestFilter> filter = new List<RequestFilter>();
            if (Filter != null)
            {
                if (Filter.idFolder.HasValue) filter.Add(new RequestFilter() { field = "idCategory", values = new List<string>() { Filter.idFolder.Value.ToString() } });
                if (Filter.idPricing.HasValue) filter.Add(new RequestFilter() { field = "idPricing", values = new List<string>() { Filter.idPricing.Value.ToString() } });
                if (Filter.LastUpdateDate.HasValue) filter.Add(new RequestFilter() { field = "LastUpdateDate", values = new List<string>() { Filter.LastUpdateDate.Value.ToString("yyyy-MM-dd") } });
                if (Filter.SKU != null && Filter.SKU.Count > 0)
                {
                    RequestFilter f = new RequestFilter() { field = "ProductSKU", values = new List<string>() };
                    f.values.AddRange(Filter.SKU);
                    filter.Add(f);
                }
                if (Filter.idItems != null && Filter.idItems.Count > 0)
                {
                    RequestFilter f = new RequestFilter() { field = "ItemId", values = new List<string>() };
                    f.values.AddRange(Filter.idItems.Select(x => x.ToString()).ToList());
                    filter.Add(f);
                }
                if (!String.IsNullOrEmpty(Filter.EAN13))
                {
                    RequestFilter f = new RequestFilter() { field = "EAN13", values = new List<string>() { Filter.EAN13 } };
                    filter.Add(f);
                }
                if (!String.IsNullOrEmpty(Filter.ProductName))
                {
                    RequestFilter f = new RequestFilter() { field = "ProductName", values = new List<string>() { Filter.ProductName } };
                    filter.Add(f);
                }
                if (Filter.ValidEAN13Code.HasValue)
                {
                    RequestFilter f = new RequestFilter() { field = "ValidEAN13Code", values = new List<string>() { Filter.ValidEAN13Code.Value.ToString() } };
                    filter.Add(f);
                }
                if (Filter.QuantityLowerThan.HasValue)
                {
                    RequestFilter f = new RequestFilter() { field = "QuantityLowerThan", values = new List<string>() { Filter.QuantityLowerThan.Value.ToString() } };
                    filter.Add(f);
                }
                if (Filter.QuantityGreaterThan.HasValue)
                {
                    RequestFilter f = new RequestFilter() { field = "QuantityGreaterThan", values = new List<string>() { Filter.QuantityGreaterThan.Value.ToString() } };
                    filter.Add(f);
                }

            }

            PagedRequest req = new PagedRequest()
            {
                Page = Page,
                PageSize = PageSize,
                filters = filter
            };


            if (Details != null && Details.Count > 0)
            {
                req.details = new List<ItemDetail>();
                Details.ForEach(det => req.details.Add(new ItemDetail() { field = det.ToString() }));
            }

            RestRequest elm = CreateRequest<PagedRequest>("Products/GetProducts", Method.POST, req);

            IRestResponse<PagedResponse<Item>> resp = await Client.ExecutePostTaskAsync<PagedResponse<Item>>(elm);

            if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();
            else
                return resp.Data;
        }
    }
}
