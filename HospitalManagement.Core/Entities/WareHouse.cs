using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Entities
{
    public class WareHouse:BaseEntity
    {
        public string Name { get; set; }

        public int Floor { get; set; }

        ICollection<Product> Products { get; set; }

        public Building Building { get; set; }

        public int BuildingId { get; set; }
    }
}
