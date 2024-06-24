using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace AppHondaDuyDuc.Model
{
    public class Order // Sửa đổi mức độ truy cập của lớp Order thành public
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("nameOrder")]
        public string NameOrder { get; set; }

        [BsonElement("products")]
        public List<Product> Products { get; set; }

        [BsonElement("sum")]
        public float Sum { get; set; }

        [BsonElement("isPay")]
        public bool IsPay { get; set; }

        [BsonElement("debt")]
        public float Debt { get; set; }

        [BsonElement("userId")]
        public string UserId { get; set; }
    }
}
