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
    public class WareHouseRepository : GenericRepository<WareHouse>, IWareHouseRepository
    {
        public WareHouseRepository(AppDbContext context) : base(context)
        {

        }

        async Task<List<WareHouse>> IWareHouseRepository.GetWareHousesWithBuilding()
        {
            return await _context.WareHouses.Include(x => x.Building).ToListAsync();
        }
    }
}
