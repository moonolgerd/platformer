using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Platformer.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(Platformer.DataStore))]
namespace Platformer
{
    public class DataStore : IDataStore<Item>
    {
        private readonly HttpClient _httpClient;
        private readonly Uri _uri;
        
        public DataStore(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _uri = new Uri(configuration["ApiUrl"]);
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            var message = await _httpClient.PostAsync(_uri, new StringContent(item.ToString()));
            return message.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var message = await _httpClient.PutAsync(_uri + item.Id, new StringContent(item.ToString()));
            return message.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var message = await _httpClient.DeleteAsync(_uri + id);
            return message.StatusCode == System.Net.HttpStatusCode.OK;
        }

        public async Task<Item> GetItemAsync(string id)
        {
            var message = await _httpClient.GetAsync(_uri + id);
            return JsonConvert.DeserializeObject<Item>(await message.Content.ReadAsStringAsync());
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            var message = await _httpClient.GetAsync(_uri);
            return JsonConvert.DeserializeObject<IEnumerable<Item>>(await message.Content.ReadAsStringAsync());
        }
    }
}