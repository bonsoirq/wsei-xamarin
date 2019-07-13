using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todorin.Models;

namespace Todorin.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = 0, Checked = false, Text = "First item", Description="This is an item description." },
                new Item { Id = 1, Checked = false, Text = "Second item", Description="This is an item description." },
                new Item { Id = 2, Checked = false, Text = "Third item", Description="This is an item description." },
                new Item { Id = 3, Checked = false, Text = "Fourth item", Description="This is an item description." },
                new Item { Id = 4, Checked = false, Text = "Fifth item", Description="This is an item description." },
                new Item { Id = 5, Checked = false, Text = "Sixth item", Description="This is an item description." },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}