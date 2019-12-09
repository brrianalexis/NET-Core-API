using ContosoAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace ContosoAPI.Services
{
    public class CoursesService
    {
        private readonly IMongoCollection<Courses> _courses;

        public CoursesService(IContosoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _courses = database.GetCollection<Courses>(settings.ContosoCollectionName);
        }

        //  C
        public Courses Create(Courses course)
        {
            _courses.InsertOne(course);
            return course;
        }

        //  R
        public List<Courses> Get() =>
            _courses.Find(course => true).ToList();

        public Courses Get(string id) =>
            _courses.Find<Courses>(course => course.Id == id).FirstOrDefault();

        //  U
        public void Update(string id, Courses courseIn) =>
            _courses.ReplaceOne(course => course.Id == id, courseIn);

        public void Remove(Courses courseIn) =>
            _courses.DeleteOne(course => course.Id == courseIn.Id);

        //  D
        public void Remove(string id) =>
            _courses.DeleteOne(course => course.Id == id);
    }
}