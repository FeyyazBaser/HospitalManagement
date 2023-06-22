using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.DTOs
{
    public class ProductDto:BaseDto
    {
        public string Name { get; set; }

        public int Stock { get; set; }

        public int WarehouseId { get; set; }
    }
}
