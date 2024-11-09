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

        public async Task UpdateOrderAsync(Order order)
        {
            await _orders.ReplaceOneAsync(o => o.Id == order.Id, order);
        }

        public async Task DeleteOrderAsync(string orderId)
        {
            await _orders.DeleteOneAsync(o => o.Id == orderId);
        }

        // find order by plates
        public async Task<List<Order>> FindOrderByPlates(string plates)
        {
            var orders = await _orders.Find(o => o.LicensePlates.Contains(plates)).ToListAsync();
            return orders;
        }

        public void Dispose()
        {
            // Clean up any resources if needed
        }
    }
}
