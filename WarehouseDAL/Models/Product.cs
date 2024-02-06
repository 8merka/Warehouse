using System.Text.Json.Serialization;

namespace WarehouseDAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public DateTime WarrantyStartDate { get; set; }
        public DateTime WarrantyEndDate { get; set; }
        [JsonIgnore]
        public Department Department { get; set; }

    }
}
