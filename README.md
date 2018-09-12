# eDock REST API SDK

Client for eDock REST API

## What is eDock
eDock is a platform that allows you to sell your products on different marketplaces (like eBay, Amazon, PixPlace, Wish...) and keep your inventory synced. 
You can configure eDock to create and close listings on your marketplaces defining what we call publishing rules.

## Why an SDK?
The real power of eDock is its ability to be integrated with different software. Even if there is the opportunity to handle inventory using CSV / XML files, the most advanced integrations are built using our rich set of REST API. eDock itself uses its own API in order to handle all of the business for the customer.

## Usage
In order to invoke our API you must, first of all, register an account on [eDock](https://www.edock.it). As soon as you have a password, you must generate a token. A token is an opaque string that let eDock REST API to identify you. A token is generated to a registered eDock App. We invite you to contact us, in order to receive your app credentials, in order to be able to generate a token.

Once you have a token, you can invoke our REST API using this syntax:

```
using eDock.Common.RestApiSDK
using eDock.Common.RestApiSDK.Services.Auth
using eDock.Common.RestApiSDK.Models.Credentials

eDockClientCredentials credentials = new eDockClientCredentials() 
{
	ClientId = [your client id],
	ClientSecret = [your client secret]
};

TokenService tokenService = new TokenService(credentials);
string AuthToken = await tokenService.RefreshAccessToken([your refresh token]);

var proxy = new eDockProxy(new eDockCredentials(AuthToken));
```


## REST API Documentation
Have a look at [our documentation](https://documenter.getpostman.com/view/235984/edock/719ZDC8), in order to have insights and examples for the low level calls!