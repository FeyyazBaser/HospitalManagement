using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.DTOs
{
    public class ProductWithWarehouseDto:ProductDto
    {
        public WarehouseDto Warehouse { get; set; }
    }
}
