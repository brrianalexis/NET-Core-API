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
    public class Courses
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("Department")]
        public string Department { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Credits")]
        public int Credits { get; set; }

        [BsonElement("Capacity")]
        public int Capacity { get; set; }

        [BsonElement("Instructors")]
        public string Instructor { get; set; }

        [BsonElement("Date")]
        //      Haga lo que haga, lo guarda en UTC y no en local
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}