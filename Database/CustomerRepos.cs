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

        // update customer
        public async Task UpdateCustomer(Customer customer)
        {
            var filter = Builders<Customer>.Filter.Eq(x => x.Id, customer.Id);
            var update = Builders<Customer>.Update
                .Set(x => x.Name, customer.Name)
                .Set(x => x.PhoneNumber, customer.PhoneNumber)
                .Set(x => x.Address, customer.Address);

            await _customers.UpdateOneAsync(filter, update);
        }

        // Tìm kiếm theo Id

        public async Task<Customer> GetCustomerById(string id)
        {
            var cursor = await _customers.FindAsync(x => x.Id == id);
            var customer = await cursor.FirstOrDefaultAsync();
            return customer;
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

        // delete
        public async Task DeleteCustomerById(string id)
        {
            await _customers.DeleteOneAsync(x => x.Id == id);
        }


        // Implement IDisposable
        public void Dispose()
        {
            // Clean up any resources if needed
        }
    }
}
