using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace E_Commerce.Catalog.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public string Description { get; set; }
        //Category alanını buraya ekliyoruz fakat bsonıgnore ile veri tabanına kaydedilmesini önlüyoruz
        public string CategoryID { get; set; }

        [BsonIgnore]
        public Category Category { get; set; }
    }
}
