using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ToDo.Domain.Models
{
    public class Entry

    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Task { get; set; }

        public DateTime CreatedOnUtc { get; set; }

    }
}
