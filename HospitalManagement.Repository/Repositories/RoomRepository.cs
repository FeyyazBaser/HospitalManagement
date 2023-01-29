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
    public class RoomRepository:GenericRepository<Room>,IRoomRepository
    {
        public RoomRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<List<Room>> GetRoomsWithBuilding()
        {
            return await _context.Rooms.Include(x => x.Building).ToListAsync();
        }
    }
}
