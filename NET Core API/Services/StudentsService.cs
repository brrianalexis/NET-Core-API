using ContosoAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace ContosoAPI.Services
{
    public class StudentsService
    {
        private readonly IMongoCollection<Students> _students;

        public StudentsService(IContosoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _students = database.GetCollection<Students>(settings.StudentsCollectionName);
        }

        //  C
        public Students Create(Students student)
        {
            _students.InsertOne(student);
            return student;
        }

        //  R
        public List<Students> Get() =>
            _students.Find(student => true).ToList();

        public Students Get(string id) =>
            _students.Find<Students>(student => student.Id == id).FirstOrDefault();

        //  U
        public void Update(string id, Students studentIn) =>
            _students.ReplaceOne(student => student.Id == id, studentIn);

        public void Remove(Students studentIn) =>
            _students.DeleteOne(student => student.Id == studentIn.Id);

        //  D
        public void Remove(string id) =>
            _students.DeleteOne(student => student.Id == id);
    }
}