using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using SupermarketApi.Contracts.Utilities;

namespace SupermarketApi.Contracts.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public double Prize { get; set; }
        public Category Categoria { get; set; }

    }
}
