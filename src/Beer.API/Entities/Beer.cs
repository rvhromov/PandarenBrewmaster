using System.Collections.Generic;
using Beer.API.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Beer.API.Entities
{
    public class Beer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public string Name { get; set; }

        public BeerType Type { get; set; }
        
        public double AverageRate { get; set; }

        public List<Feedback> Feedbacks { get; set; } = new();
    }
}