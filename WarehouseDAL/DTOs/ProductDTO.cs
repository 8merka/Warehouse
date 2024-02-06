using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseDAL.DTO
{
    public class ProductDTO
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public DateTime WarrantyStartDate { get; set; }
        public DateTime WarrantyEndDate { get; set; }
    }
}
