using eDock.Common.RestApiSDK.Models.Credentials;
using eDock.Common.RestApiSDK.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eDock.Common.RestApiSDK
{
    public class eDockProxy
    {
        private eDockCredentials _Credentials;
        private ItemService _Items;
        private OrderService _Orders;
        private PricelistService _Pricelists;
        private FolderService _FolderService;
        private AmazonProxy _Amazon;
        private CurrencyService _Currency;
        private ImageService _Images;
        private AttributeService _Attributes;
        private ModuleService _Modules;
        private CustomOrderExportService _CustomOrderExport;
        private UsersService _UsersService;
        private TrackingService _TrackingService;

        public CustomOrderExportService CustomOrderExports
        {
            get
            {
                if (_CustomOrderExport == null)
                    _CustomOrderExport = new CustomOrderExportService(_Credentials);

                return _CustomOrderExport;
            }
        }

        public UsersService Users
        {
            get
            {
                if (_UsersService == null)
                    _UsersService = new UsersService(_Credentials);

                return _UsersService;
            }
        }

        public ItemService Items
        {
            get
            {
                if (_Items == null)
                    _Items = new ItemService(_Credentials);

                return _Items;
            }
        }

        public FolderService Folders
        {
            get
            {
                if (_FolderService == null)
                    _FolderService = new FolderService(_Credentials);

                return _FolderService;
            }
        }

        public OrderService Orders
        {
            get
            {
                if (_Orders == null)
                    _Orders = new OrderService(_Credentials);
                
                return _Orders;
            }
        }

        public PricelistService Pricelists
        {
            get
            {
                if (_Pricelists == null)
                    _Pricelists = new PricelistService(_Credentials);

                return _Pricelists;
            }
        }

        public AmazonProxy Amazon
        {
            get
            {
                if (_Amazon == null)
                    _Amazon = new AmazonProxy(_Credentials);

                return _Amazon;
            }
        }

        public CurrencyService Currency
        {
            get
            {
                if (_Currency == null)
                    _Currency = new CurrencyService(_Credentials);
                
                return _Currency;
            }
        }

        public ImageService Images
        {
            get
            {
                if (_Images == null)
                    _Images = new ImageService(_Credentials);

                return _Images;
            }
        }

        public AttributeService Attributes
        {
            get
            {
                if (_Attributes == null)
                    _Attributes = new AttributeService(_Credentials);

                return _Attributes;
            }
        }

        public ModuleService Modules
        {
            get
            {
                if (_Modules == null)
                    _Modules = new ModuleService(_Credentials);

                return _Modules;
            }
        }

        public TrackingService Tracking
        {
            get
            {
                if (_TrackingService == null)
                    _TrackingService = new TrackingService(_Credentials);

                return _TrackingService;
            }
        }

        public eDockProxy(eDockCredentials Credentials)
        {
            if (Credentials == null) throw new Exception();
            _Credentials = Credentials;
        }
    }

    public class AmazonProxy
    {
        private eDockCredentials _Credentials;
        public AmazonProxy(eDockCredentials Credentials)
        {
            _Credentials = Credentials;
        }

        private eDock.Common.RestApiSDK.Services.Amazon.SubscriptionService _SubscriptionService;

        public eDock.Common.RestApiSDK.Services.Amazon.SubscriptionService Subscriptions
        {
            get
            {
                if (_SubscriptionService == null)
                    _SubscriptionService = new eDock.Common.RestApiSDK.Services.Amazon.SubscriptionService(_Credentials);

                return _SubscriptionService;
            }
        }
    }
}

