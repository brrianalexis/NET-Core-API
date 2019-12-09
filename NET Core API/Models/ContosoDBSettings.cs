namespace ContosoAPI.Models
{
    public class ContosoDBSettings : IContosoDBSettings
    {
        public string ContosoCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IContosoDBSettings
    {
        string ContosoCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}