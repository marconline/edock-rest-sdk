using eDock.Common.RestApiSDK.Models;
using eDock.Common.RestApiSDK.Models.Credentials;
using eDock.Common.RestApiSDK.Models.Exceptions;
using eDock.Common.RestApiSDK.Models.Items;
using eDock.Common.RestApiSDK.Models.Orders;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK.Services
{
    public class OrderService : BaseRestService
    {
        public OrderService(eDockCredentials Credentials)
            : base(Credentials)
        {

        }

        public void Create(Order Order)
        {
            RestRequest elm = CreateRequest<Order>("Orders/Add", Method.POST, Order);
            IRestResponse<OrderCreateResponse> resp = Client.Execute<OrderCreateResponse>(elm);

            if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();
            else if (resp.StatusCode != HttpStatusCode.OK)
            {
                throw new eDockAPIException();
            }
        }

        public Order Get(int idOrder)
        {
            RestRequest elm = CreateRequest<Order>("Orders/GetFull/{idOrder}", Method.GET, null);
            elm.AddParameter("idOrder", idOrder, ParameterType.UrlSegment);
            IRestResponse<Order> resp = Client.Execute<Order>(elm);

            if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();
            else if (resp.StatusCode != HttpStatusCode.OK)
            {
                throw new eDockAPIException();
            }

            return resp.Data;
        }

        public async Task<PagedResponse<Order>> GetInStatus(int idOrderStatus, int Page = 0, int PageSize = 50, bool SortByCreationDateAscending = false)
        {
            PagedRequest req = new PagedRequest()
            {
                Page = Page,
                PageSize = PageSize,
                filters = new List<RequestFilter>() {
                    new RequestFilter() {
                        field = "idStatusFilter",
                        values = new List<string>() { idOrderStatus.ToString() }
                    }
                },
            };

            if (SortByCreationDateAscending)
            {
                req.sort = new Sort() { Field = "CreatedOn", Verb = "asc" };
            }

            RestRequest elm = CreateRequest<PagedRequest>("Orders/GetOrders", Method.POST, req);

            IRestResponse<PagedResponse<Order>> resp = await Client.ExecutePostTaskAsync<PagedResponse<Order>>(elm);

            if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();
            else if (resp.StatusCode != HttpStatusCode.OK)
            {
                throw new eDockAPIException();
            }

            return resp.Data;
        }

        public List<OrderStatus> GetAllStatuses()
        {
            RestRequest elm = CreateGetRequest("OrderStatus/All");
            IRestResponse<List<OrderStatus>> resp = Client.Get<List<OrderStatus>>(elm);

            if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();
            else if (resp.StatusCode != HttpStatusCode.OK)
            {
                throw new eDockAPIException();
            }

            return resp.Data;
        }

        public void Move(OrderMoveRequest Move)
        {
            RestRequest elm = CreateRequest<OrderMoveRequest>("Orders/Move", Method.POST, Move);
            IRestResponse resp = Client.Execute(elm);

            if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();
            else if (resp.StatusCode != HttpStatusCode.OK)
            {
                throw new eDockAPIException();
            }
        }

        public void AddNote(AddNoteRequest AddNote)
        {
            RestRequest elm = CreateRequest<AddNoteRequest>("Orders/Notes", Method.POST, AddNote);
            IRestResponse resp = Client.Execute(elm);

            if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();
            else if (resp.StatusCode != HttpStatusCode.OK)
            {
                throw new eDockAPIException();
            }
        }

        public async Task<PagedResponse<Order>> Search(OrderSearchFilter Filter, int Page = 0, int PageSize = 50)
        {
            return await Search(Filter, null, Page, PageSize);
        }

        public async Task<PagedResponse<Order>> Search(OrderSearchFilter Filter, OrderDetailLevelEnum? Details = null, int Page = 0, int PageSize = 50)
        {
            List<RequestFilter> filter = new List<RequestFilter>();
            if (Filter != null)
            {
                if (Filter.CreatedOnEnd.HasValue) filter.Add(new RequestFilter() { field = "CreatedOnEnd", values = new List<string>() { Filter.CreatedOnEnd.Value.ToString("yyyy-MM-dd") } });
                if (Filter.CreatedOnStart.HasValue) filter.Add(new RequestFilter() { field = "CreatedOnStart", values = new List<string>() { Filter.CreatedOnStart.Value.ToString("yyyy-MM-dd") } });

                if (Filter.CreatedOneDockEnd.HasValue) filter.Add(new RequestFilter() { field = "CreatedOneDockEnd", values = new List<string>() { Filter.CreatedOneDockEnd.Value.ToString("yyyy-MM-dd") } });
                if (Filter.CreatedOneDockStart.HasValue) filter.Add(new RequestFilter() { field = "CreatedOneDockStart", values = new List<string>() { Filter.CreatedOneDockStart.Value.ToString("yyyy-MM-dd") } });

                if (Filter.UpdatedOnEnd.HasValue) filter.Add(new RequestFilter() { field = "UpdatedOnEnd", values = new List<string>() { Filter.UpdatedOnEnd.Value.ToString("yyyy-MM-dd") } });
                if (Filter.UpdatedOnStart.HasValue) filter.Add(new RequestFilter() { field = "UpdatedOnStart", values = new List<string>() { Filter.UpdatedOnStart.Value.ToString("yyyy-MM-dd") } });

                if (Filter.idStatusFilter.HasValue) filter.Add(new RequestFilter() { field = "idStatusFilter", values = new List<string>() { Filter.idStatusFilter.Value.ToString() } });
                if (Filter.OrderIdGreaterOrEqualThan.HasValue) filter.Add(new RequestFilter() { field = "OrderIdGreaterOrEqualThan", values = new List<string>() { Filter.OrderIdGreaterOrEqualThan.Value.ToString() } });
                if (Filter.OrderIdLowerOrEqualThan.HasValue) filter.Add(new RequestFilter() { field = "OrderIdLowerOrEqualThan", values = new List<string>() { Filter.OrderIdLowerOrEqualThan.Value.ToString() } });
                if (Filter.Paid.HasValue) filter.Add(new RequestFilter() { field = "Paid", values = new List<string>() { Filter.Paid.Value.ToString() } });
                if (Filter.ShippedOnEnd.HasValue) filter.Add(new RequestFilter() { field = "ShippedOnEnd", values = new List<string>() { Filter.ShippedOnEnd.Value.ToString() } });
                if (Filter.ShippedOnStart.HasValue) filter.Add(new RequestFilter() { field = "ShippedOnStart", values = new List<string>() { Filter.ShippedOnStart.Value.ToString() } });
                if (!String.IsNullOrEmpty(Filter.SKU)) filter.Add(new RequestFilter() { field = "SKU", values = new List<string>() { Filter.SKU } });

                if (Filter.OrderId.HasValue) filter.Add(new RequestFilter() { field = "OrderId", values = new List<string>() { Filter.OrderId.Value.ToString() } });
                if (!String.IsNullOrEmpty(Filter.CustomerFilter)) filter.Add(new RequestFilter() { field = "CustomerFilter", values = new List<string>() { Filter.CustomerFilter } });
                if (!String.IsNullOrEmpty(Filter.eBayUsername)) filter.Add(new RequestFilter() { field = "eBayUsername", values = new List<string>() { Filter.eBayUsername } });
                if (Filter.idCountry.HasValue) filter.Add(new RequestFilter() { field = "idCountry", values = new List<string>() { Filter.idCountry.Value.ToString() } });
                if (Filter.idCounty.HasValue) filter.Add(new RequestFilter() { field = "idCounty", values = new List<string>() { Filter.idCounty.Value.ToString() } });
                if (Filter.idCurrency.HasValue) filter.Add(new RequestFilter() { field = "idCurrency", values = new List<string>() { Filter.idCurrency.Value.ToString() } });
                if (Filter.idPaymentMethod.HasValue) filter.Add(new RequestFilter() { field = "idPaymentMethod", values = new List<string>() { Filter.idPaymentMethod.Value.ToString() } });
                if (Filter.ModuleIDFilter.HasValue) filter.Add(new RequestFilter() { field = "ModuleIDFilter", values = new List<string>() { Filter.ModuleIDFilter.Value.ToString() } });
                if (!String.IsNullOrEmpty(Filter.CustomerEmail)) filter.Add(new RequestFilter() { field = "CustomerEmail", values = new List<string>() { Filter.CustomerEmail } });

                if (!String.IsNullOrEmpty(Filter.MarketplaceOrderId)) filter.Add(new RequestFilter() { field = "MarketplaceOrderId", values = new List<string>() { Filter.MarketplaceOrderId } });
                if (!String.IsNullOrEmpty(Filter.eBaySellerUser)) filter.Add(new RequestFilter() { field = "eBaySellerUser", values = new List<string>() { Filter.eBaySellerUser } });
                if (!String.IsNullOrEmpty(Filter.SellingManagerSalesRecordNumber)) filter.Add(new RequestFilter() { field = "SellingManagerSalesRecordNumber", values = new List<string>() { Filter.SellingManagerSalesRecordNumber } });

            }

            List<ItemDetail> details = new List<ItemDetail>();
            if (Details.HasValue)
            {
                if (Details.Value.HasFlag(OrderDetailLevelEnum.BillingAddress)) details.Add(new ItemDetail() { field = "BillingAddress" });
                if (Details.Value.HasFlag(OrderDetailLevelEnum.ContactInformations)) details.Add(new ItemDetail() { field = "ContactInformations" });
                if (Details.Value.HasFlag(OrderDetailLevelEnum.ExternalSellerReference)) details.Add(new ItemDetail() { field = "ExternalSellerReference" });
                if (Details.Value.HasFlag(OrderDetailLevelEnum.History)) details.Add(new ItemDetail() { field = "History" });
                if (Details.Value.HasFlag(OrderDetailLevelEnum.Payments)) details.Add(new ItemDetail() { field = "Payments" });
                if (Details.Value.HasFlag(OrderDetailLevelEnum.Rows)) details.Add(new ItemDetail() { field = "Rows" });
                if (Details.Value.HasFlag(OrderDetailLevelEnum.RowVariationAttributes)) details.Add(new ItemDetail() { field = "RowVariationAttributes" });
                if (Details.Value.HasFlag(OrderDetailLevelEnum.ShippingAddress)) details.Add(new ItemDetail() { field = "ShippingAddress" });
            }

            PagedRequest req = new PagedRequest()
            {
                Page = Page,
                PageSize = PageSize,
                filters = filter,
                details = details
            };

            RestRequest elm = CreateRequest<PagedRequest>("Orders/GetOrders", Method.POST, req);

            IRestResponse<PagedResponse<Order>> resp = await Client.ExecutePostTaskAsync<PagedResponse<Order>>(elm);

            if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedException();
            else if (resp.StatusCode != HttpStatusCode.OK)
            {
                throw new eDockAPIException();
            }

            return resp.Data;
        }

        public async Task<bool> ShipOrder(ShipOrderRequest Request)
        {
            RestRequest elm = CreateRequest<ShipOrderRequest>("Orders/TrackingInfo", Method.POST, Request);
            IRestResponse resp = await Client.ExecutePostTaskAsync(elm);

            if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedAccessException();
            else if (resp.StatusCode != HttpStatusCode.OK)
                throw new eDockAPIException();
            else
                return true;
        }


        public async Task<bool> MarkOrderAsPaid(int idOrder)
        {
            RestRequest elm = CreateRequest<List<int>>("Orders/MarkAsPaid", Method.POST, new List<int>() { idOrder });
            IRestResponse resp = await Client.ExecutePostTaskAsync(elm);

            if (resp.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedAccessException();
            else if (resp.StatusCode != HttpStatusCode.OK)
                throw new eDockAPIException();
            else
                return true;
        }
    }
}

