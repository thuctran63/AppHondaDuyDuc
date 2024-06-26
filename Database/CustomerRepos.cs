using AppHondaDuyDuc.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppHondaDuyDuc.Database
{
    public class CustomerRepos : IDisposable
    {
        private readonly IMongoCollection<Customer> _customers;

        public CustomerRepos()
        {
            _customers = Mongo.Customers;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _customers.Find(_ => true).ToListAsync();
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            await _customers.InsertOneAsync(customer);
        }

        public async Task<List<Customer>> GetCustomerByName(string name)
        {
            // Tìm kiếm theo tên (chữ thường) có chứa name (chữ thường)
            var cursor = await _customers.FindAsync(x => x.Name.ToLower().Contains(name.ToLower()));
            var customers = await cursor.ToListAsync();

            return customers;
        }

        public async Task<List<Customer>> GetCustomerByPhoneNumber(string phoneNumber)
        {
            var cursor = await _customers.FindAsync(x => x.PhoneNumber.Contains(phoneNumber));
            var customers = await cursor.ToListAsync();
            return customers;
        }


        public async Task<List<Customer>> GetCustomerByAddress(string address)
        {
            var filter = Builders<Customer>.Filter.Where(x =>
                x.Address.Wards.ToLower().Contains(address.ToLower()) ||
                x.Address.Village.ToLower().Contains(address.ToLower()) ||
                x.Address.Province.ToLower().Contains(address.ToLower())
            );

            var cursor = await _customers.FindAsync(filter);
            var customers = await cursor.ToListAsync();
            return customers;
        }


        // Implement IDisposable
        public void Dispose()
        {
            // Clean up any resources if needed
        }
    }
}
