using HospitalManagement.Core.Entities;
using HospitalManagement.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Repository.Repositories
{
    public class WarehouseRepository : GenericRepository<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(AppDbContext context) : base(context)
        {

        }

        async Task<List<Warehouse>> IWarehouseRepository.GetWarehousesWithBuilding()
        {
            return await _context.Warehouses.Include(x => x.Building).ToListAsync();
        }
    }
}
