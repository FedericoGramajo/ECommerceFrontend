﻿using ClientLibrary.Helper;
using ClientLibrary.Models;
using ClientLibrary.Models.Cart;

namespace ClientLibrary.Services
{
    public class CartService(IHttpClientHelper httpClient, IApiCallHelper apiHelper) : ICartService
    {
        public async Task<ServiceResponse> Checkout(Checkout checkout)
        {
            var priuvateClient = await httpClient.GetPrivateClientAsync();
            var apiCallModel = new ApiCall
            {
                Route = Constant.Cart.Checkout,
                Type = Constant.ApiCallType.Post,
                Client = priuvateClient,
                Id= null!,
                Model = checkout
            };
            var result = await apiHelper.ApiCallTypeCall<Checkout>(apiCallModel);
            if (result == null)
                return apiHelper.ConnectionError();
            else
                return await apiHelper.GetServiceResponse<ServiceResponse>(result);
        }

        public async Task<ServiceResponse> SaveCheckoutHistory(IEnumerable<CreateAchieve> achieves)
        {
            var priuvateClient = await httpClient.GetPrivateClientAsync();
            var apiCallModel = new ApiCall
            {
                Route = Constant.Cart.SaveCart,
                Type = Constant.ApiCallType.Post,
                Client = priuvateClient,
                Id = null!,
                Model = achieves
            };
            var result = await apiHelper.ApiCallTypeCall<IEnumerable<Checkout>>(apiCallModel);
            if (result == null)
                return apiHelper.ConnectionError();
            else
                return await apiHelper.GetServiceResponse<ServiceResponse>(result);
        }
    }
}
