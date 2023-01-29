using AutoMapper;
using HospitalManagement.Core.DTOs;
using HospitalManagement.Core.Entities;
using HospitalManagement.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController :CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Room> _service;
        public RoomsController(IService<Room> service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var Rooms = await _service.GetAllAsync();
            var RoomDtos = _mapper.Map<List<RoomDto>>(Rooms.ToList());
            return CreateActionResult(CustomResponseDto<List<RoomDto>>.Success(200, RoomDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Room = await _service.GetByIdAsync(id);
            var RoomDto = _mapper.Map<RoomDto>(Room);
            return CreateActionResult(CustomResponseDto<RoomDto>.Success(200, RoomDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(RoomDto RoomDto)
        {
            var Room = await _service.AddAsync(_mapper.Map<Room>(RoomDto));
            var RoomsDto = _mapper.Map<RoomDto>(Room);
            return CreateActionResult(CustomResponseDto<RoomDto>.Success(201, RoomsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(RoomDto RoomDto)
        {
            await _service.UpdateAsync(_mapper.Map<Room>(RoomDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var Room = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(Room);
            return CreateActionResult(CustomResponseDto<List<NoContentDto>>.Success(204));
        }

    }
}
