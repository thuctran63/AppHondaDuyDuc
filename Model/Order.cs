using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace AppHondaDuyDuc.Model
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("nameOrder")]
        public string NameOrder { get; set; }

        [BsonElement("desciption")]
        public string Desciption { get; set; }

        [BsonElement("licensePlates")]
        public string LicensePlates { get; set; }

        [BsonElement("products")]
        public List<Product> Products { get; set; } = new List<Product>();

        [BsonElement("time")]
        public DateTime Time { get; set; }

        [BsonElement("sum")]
        public double Sum { get; set; }

        [BsonElement("debt")]
        public double Debt { get; set; }

        [BsonElement("userId")]
        public string UserId { get; set; }

        // Constructor mặc định
        public Order()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }
    }
}
