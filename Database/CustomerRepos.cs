using AppHondaDuyDuc.Model;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace AppHondaDuyDuc.Data
{
    public class CustomerRepos
    {
        private readonly IMongoCollection<Customer> _customers;

        public CustomerRepos()
        {
            _customers = MongoDB.Customers;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            await _customers.InsertOneAsync(customer);
        }
    }
}
