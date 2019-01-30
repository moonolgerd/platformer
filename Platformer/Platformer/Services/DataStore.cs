﻿using Platformer.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(Platformer.DataStore))]
namespace Platformer
{
    public class DataStore : IDataStore<Item>
    {
        List<Item> items;

        public DataStore()
        {
            
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id) => await Task.FromResult(items.FirstOrDefault(s => s.Id == id));

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false) => await Task.FromResult(items);
    }
}
