using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.DTOs
{
    public class RoomWithBuildingDto:RoomDto
    {
        public BuildingDto Building { get; set; }
    }
}
