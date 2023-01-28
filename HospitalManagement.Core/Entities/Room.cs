using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Entities
{
    public class Room:BaseEntity
    {     
        public int Number { get; set; }

        public int Floor { get; set; }

        public Building Building { get; set; }

        public int BuildingId { get; set; }
    }
}
