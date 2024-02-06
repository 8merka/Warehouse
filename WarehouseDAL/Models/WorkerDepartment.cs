using System.Text.Json.Serialization;

namespace WarehouseDAL.Models
{
    public class WorkerDepartment
    {
        public int WorkerId { get; set; }
        public int DepartmentId { get; set; }
        [JsonIgnore]
        public Worker Worker { get; set; }
        [JsonIgnore]
        public Department Department { get; set; }
    }
}
