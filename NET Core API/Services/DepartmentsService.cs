using ContosoAPI.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace ContosoAPI.Services
{
    public class DepartmentsService
    {
        private readonly IMongoCollection<Departments> _departments;

        public DepartmentsService(IContosoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _departments = database.GetCollection<Departments>(settings.DepartmentsCollectionName);
        }

        //  C
        public Departments Create(Departments department)
        {
            _departments.InsertOne(department);
            return department;
        }

        //  R
        public List<Departments> Get() =>
            _departments.Find(department => true).ToList();

        public Departments Get(string id) =>
            _departments.Find<Departments>(department => department.Id == id).FirstOrDefault();

        //  U
        public void Update(string id, Departments departmentIn) =>
            _departments.ReplaceOne(department => department.Id == id, departmentIn);

        public void Remove(Departments departmentIn) =>
            _departments.DeleteOne(department => department.Id == departmentIn.Id);

        //  D
        public void Remove(string id) =>
            _departments.DeleteOne(department => department.Id == id);
    }
}