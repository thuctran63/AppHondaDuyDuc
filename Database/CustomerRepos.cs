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

        // Implement IDisposable
        public void Dispose()
        {
            // Clean up any resources if needed
        }
    }
}
