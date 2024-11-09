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

        public override bool Equals(object obj)
        {
            // Kiểm tra đối tượng này có phải là một Customer không
            if (obj is Customer other)
            {
                // So sánh các thuộc tính mà bạn cho là quan trọng để xác định Customer trùng
                return this.Id == other.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            // Trả về mã băm dựa trên thuộc tính mà bạn muốn so sánh (ví dụ: CustomerId)
            return this.Id.GetHashCode();
        }
    }
}
