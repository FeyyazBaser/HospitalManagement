﻿using HospitalManagement.Core.DTOs;
using HospitalManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Core.Service
{
    public interface IWarehouseService:IService<Warehouse>
    {
        Task<CustomResponseDto<List<WarehouseWithBuildingDto>>> GetWarehousesWithBuilding();
    }
}
