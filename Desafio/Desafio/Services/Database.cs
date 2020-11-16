using Desafio.Repository;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Services
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<AddressRepository>().Wait();
        }

        public async Task<List<AddressRepository>> GetAddressAsync()
        {
            return await _database.Table<AddressRepository>().ToListAsync();
        }

        public async Task<int> SaveAddressAsync(AddressRepository address)
        {
            return await _database.InsertAsync(address);
        }


    }
}
