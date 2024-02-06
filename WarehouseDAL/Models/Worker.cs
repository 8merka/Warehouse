using System.Text.Json.Serialization;

namespace WarehouseDAL.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        [JsonIgnore]
        public List<WorkerDepartment> WorkerDepartments { get; set; }
    }
}
