using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace AppHondaDuyDuc.Model
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("phoneNumber")]
        public string PhoneNumber { get; set; }

        [BsonElement("address")]
        public Address Address { get; set; }

        [BsonElement("orders")]
        public List<string> OrderIds { get; set; }

        [BsonElement("debt")]
        public double Debt { get; set; }

        public Customer()
        {
            Id = ObjectId.GenerateNewId().ToString();
            OrderIds = new List<string>();
        }
    }
}
