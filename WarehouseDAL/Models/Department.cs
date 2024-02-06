using System.Text.Json.Serialization;

namespace WarehouseDAL.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Product> Products { get; set; }
        [JsonIgnore]
        public List<WorkerDepartment> WorkerDepartments { get; set; }
    }
}
