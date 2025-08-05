using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyShop.Entities
{
    public class ProductDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductDetailId { get; set; }
        public string Description { get; set; }
        public string Information { get; set; }
        public string ProductId { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }
    }
}
