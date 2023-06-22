using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.DTOs
{
    public class WarehouseDto : BaseDto
    {
        public string Name { get; set; }

        public int Floor { get; set; }

        public int BuildingId { get; set; }
    }
}
