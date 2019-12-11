using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//  MongoDB
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace ContosoAPI.Models
{
    public class Instructors
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Date")]
        //      Haga lo que haga, lo guarda en UTC y no en local
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}