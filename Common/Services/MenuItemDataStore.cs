﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Common.Services;

namespace Common
{
    public class MenuItemDataStore : IDataStore<MenuItemEntityModel>
    {
        public static string urlMenuItem = "http://172.30.1.105:44333/api/menuitem/";
        public static string urlFieldItem = "http://172.30.1.105:44333/api/fielditem/";


        public Task<MenuItemEntityModel> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<MenuItemEntityModel>> GetItemsAsync()
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(urlMenuItem))
            {
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<MenuItemEntityModel>>();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<Uri> AddItemAsync(MenuItemEntityModel item)
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(urlMenuItem, item);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        public async Task<MenuItemEntityModel> UpdateItemAsync(MenuItemEntityModel item, int id)
        {
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync(urlMenuItem + id, item))
            {
                response.EnsureSuccessStatusCode();

                item = await response.Content.ReadAsAsync<MenuItemEntityModel>();
                return item;
            }
        }

        public async Task<HttpStatusCode> DeleteItemAsync(int id)
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync(urlMenuItem + id);
            return response.StatusCode;
        }
    }
}
