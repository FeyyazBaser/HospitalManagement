using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Entities
{
    public class Building:BaseEntity
    {
        public string Name { get; set; }

        ICollection<Warehouse> Warehouses { get; set;}

        ICollection<Room> Rooms { get; set;}
    }
}
