using AppHondaDuyDuc.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppHondaDuyDuc.Database
{
    public class OrderRepos : IDisposable
    {
        private readonly IMongoCollection<Order> _orders;

        public OrderRepos()
        {
            _orders = Mongo.Orders;
        }

        public async Task<List<Order>> GetAllOrderOfCustomer(string customerId)
        {
            var orders = await _orders.Find(o => o.UserId == customerId).ToListAsync();
            return orders;
        }


        public async Task AddOrderAsync(Order order)
        {
            await _orders.InsertOneAsync(order);
        }

        public void Dispose()
        {
            // Clean up any resources if needed
        }
    }
}
