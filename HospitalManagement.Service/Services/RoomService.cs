using AutoMapper;
using HospitalManagement.Core.DTOs;
using HospitalManagement.Core.Entities;
using HospitalManagement.Core.Repositories;
using HospitalManagement.Core.Service;
using HospitalManagement.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Service.Services
{
    public class RoomService :Service<Room>,IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public RoomService(IGenericRepository<Room> repository, IUnitOfWork unitOfWork, IMapper mapper, IRoomRepository roomRepository) : base(repository, unitOfWork)
        {

            _mapper = mapper;
            _roomRepository = roomRepository;
        }

        public async Task<CustomResponseDto<List<RoomWithBuildingDto>>> GetRoomsWithBuilding()
        {
            var rooms = await _roomRepository.GetRoomsWithBuilding();

            var roomsDto = _mapper.Map<List<RoomWithBuildingDto>>(rooms);

            return CustomResponseDto<List<RoomWithBuildingDto>>.Success(200, roomsDto);
        }
    }
}
