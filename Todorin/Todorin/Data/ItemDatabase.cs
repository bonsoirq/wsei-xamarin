using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SQLite;
using Todorin.Models;
using Todorin.Services;

namespace Todorin.Data
{
    public class ItemDatabase : IDataStore<Item>
    {
        readonly SQLiteAsyncConnection _database;

        public ItemDatabase()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Items.db3");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Item>().Wait();
        }

        public ItemDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Item>().Wait();
        }

        public Task<List<Item>> GetTodorinAsync()
        {
            return _database.Table<Item>().ToListAsync();
        }

        public Task<Item> GetItemAsync(int Id)
        {
            return _database.Table<Item>()
                            .Where(i => i.Id == Id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> DeleteItemAsync(Item Item)
        {
            return _database.DeleteAsync(Item);
        }

        public Task<int> AddItemAsync(Item Item)
        {
            return _database.InsertAsync(Item);
        }

        public Task<int> UpdateItemAsync(Item Item)
        {
            return _database.UpdateAsync(Item);
        }

        public Task<int> DeleteItemAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await _database.Table<Item>().ToListAsync();
        }

    }
}