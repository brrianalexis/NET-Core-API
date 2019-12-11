using ContosoAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace ContosoAPI.Services
{
    public class InstructorsService
    {
        private readonly IMongoCollection<Instructors> _instructors;

        public InstructorsService(IContosoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _instructors = database.GetCollection<Instructors>(settings.InstructorsCollectionName);
        }

        //  C
        public Instructors Create(Instructors instructor)
        {
            _instructors.InsertOne(instructor);
            return instructor;
        }

        //  R
        public List<Instructors> Get() =>
            _instructors.Find(instructor => true).ToList();

        public Instructors Get(string id) =>
            _instructors.Find<Instructors>(instructor => instructor.Id == id).FirstOrDefault();

        //  U
        public void Update(string id, Instructors instructorIn) =>
            _instructors.ReplaceOne(instructor => instructor.Id == id, instructorIn);

        public void Remove(Instructors instructorIn) =>
            _instructors.DeleteOne(instructor => instructor.Id == instructorIn.Id);

        //  D
        public void Remove(string id) =>
            _instructors.DeleteOne(instructor => instructor.Id == id);
    }
}