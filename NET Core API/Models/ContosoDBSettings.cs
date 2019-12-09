namespace ContosoAPI.Models
{
    public class ContosoDBSettings : IContosoDBSettings
    {
        public string CoursesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IContosoDBSettings
    {
        string CoursesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}