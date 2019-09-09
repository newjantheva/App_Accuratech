﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    public class RegistrationValueDataStore : IDataStore<RegistrationValueModel>
    {
        public static string urlRegistrationValues = "http://172.30.1.105:44333/api/registrationvalues";

        public async Task<Uri> AddItemAsync(ICollection<RegistrationValueModel> value)
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(urlRegistrationValues, value);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        public Task<RegistrationValueModel> UpdateItemAsync(RegistrationValueModel item, int id)
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> DeleteItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RegistrationValueModel> GetItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<RegistrationValueModel>> GetItemsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> AddItemAsync(RegistrationValueModel item)
        {
            throw new NotImplementedException();
        }
    }
}