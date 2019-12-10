namespace ContosoAPI.Models
{
    public class ContosoDBSettings : IContosoDBSettings
    {
        public string CoursesCollectionName { get; set; }
        public string DepartmentsCollectionName { get; set; }
        public string InstructorsCollectionName { get; set; }
        public string StudentsCollectionName { get; set; }
        public string UsersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IContosoDBSettings
    {
        string CoursesCollectionName { get; set; }
        string DepartmentsCollectionName { get; set; }
        string InstructorsCollectionName { get; set; }
        string StudentsCollectionName { get; set; }
        string UsersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}