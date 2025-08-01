﻿using ClientLibrary.Helper;
using ClientLibrary.Models;
using ClientLibrary.Models.Category;
using ClientLibrary.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClientLibrary.Helper.Constant;

namespace ClientLibrary.Services
{
    public class CategoryService(IHttpClientHelper httpClient, IApiCallHelper apiHelper) : ICategoryService
    {
        public async Task<ServiceResponse> AddAsync(CreateCategory category)
        {
            var client = await httpClient.GetPrivateClientAsync();
            var apiCall = new ApiCall
            {
                Route = Constant.Category.Add,
                Type = Constant.ApiCallType.Post,
                Client = client,
                Id = null!,
                Model = category
            };
            var result = await apiHelper.ApiCallTypeCall<CreateCategory>(apiCall);
            return result == null ? apiHelper.ConnectionError() : await apiHelper.GetServiceResponse<ServiceResponse>(result);
        }
        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            var client = await httpClient.GetPrivateClientAsync();
            var apiCall = new ApiCall
            {
                Route = Constant.Category.Delete,
                Type = Constant.ApiCallType.Delete,
                Client = client,
                Model = null!
            };
            apiCall.ToString(id);
            var result = await apiHelper.ApiCallTypeCall<Dummy>(apiCall);
            return result == null ? apiHelper.ConnectionError() : await apiHelper.GetServiceResponse<ServiceResponse>(result);
        }
        public async Task<ServiceResponse> UpdateAsync(UpdateCategory category)
        {

            var client = await httpClient.GetPrivateClientAsync();
            var apiCall = new ApiCall
            {
                Route = Constant.Category.Update,
                Type = Constant.ApiCallType.Update,
                Client = client,
                Id = null!,
                Model = category
            };
            var result = await apiHelper.ApiCallTypeCall<UpdateCategory>(apiCall);
            return result == null ? apiHelper.ConnectionError() : await apiHelper.GetServiceResponse<ServiceResponse>(result);
        }

        public async Task<IEnumerable<GetCategory>> GetAllAsync()
        {
            var client =  httpClient.GetPublicClient();
            var apiCall = new ApiCall
            {
                Route = Constant.Category.GetAll,
                Type = Constant.ApiCallType.Get,
                Client = client,
                Model = null!,
                Id = null!
            };
            var result = await apiHelper.ApiCallTypeCall<Dummy>(apiCall);

            if (result.IsSuccessStatusCode)
                return await apiHelper.GetServiceResponse<IEnumerable<GetCategory>>(result);
            else
                return [];
        }

        public async Task<GetCategory> GetByIdAsync(Guid id)
        {
            var client = httpClient.GetPublicClient();
            var apiCall = new ApiCall
            {
                Route = Constant.Category.Get,
                Type = Constant.ApiCallType.Get,
                Client = client,
                Model = null!
            };
            apiCall.ToString(id);
            var result = await apiHelper.ApiCallTypeCall<Dummy>(apiCall);
            if (result.IsSuccessStatusCode)
                return await apiHelper.GetServiceResponse<GetCategory>(result);
            else
                return null!;
        }

        public async Task<IEnumerable<GetProduct>> GetProductsByCategory(Guid categoryId)
        {
            var client = httpClient.GetPublicClient();
            var apiCall = new ApiCall
            {
                Route = Constant.Category.GetProductByCategory,
                Type = Constant.ApiCallType.Get,
                Client = client,
                Model = null!
            };
            apiCall.ToString(categoryId);
            var result = await apiHelper.ApiCallTypeCall<Dummy>(apiCall);

            if (result.IsSuccessStatusCode)
                return await apiHelper.GetServiceResponse<IEnumerable<GetProduct>>(result);
            else
                return [];
        }
    }
}
