using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.API.Entities
{
    public class BaseEntity
    {
        [BsonId]
        public Guid Id { get; set; }
    }
}
