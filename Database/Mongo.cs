using AppHondaDuyDuc.Model;
using MongoDB.Driver;

namespace AppHondaDuyDuc.Database
{
    public static class Mongo
    {
        private static readonly IMongoDatabase _database;

        static Mongo()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _database = client.GetDatabase("DuyDuc");
        }

        public static IMongoCollection<Customer> Customers => _database.GetCollection<Customer>("Customers");

        public static IMongoCollection<Order> Orders => _database.GetCollection<Order>("Orders");
    }
}
