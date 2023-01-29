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
    public class WareHousesController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<WareHouse> _service;
        public WareHousesController(IService<WareHouse> service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var WareHouses = await _service.GetAllAsync();
            var WareHouseDtos = _mapper.Map<List<WareHouseDto>>(WareHouses.ToList());
            return CreateActionResult(CustomResponseDto<List<WareHouseDto>>.Success(200, WareHouseDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var WareHouse = await _service.GetByIdAsync(id);
            var WareHouseDto = _mapper.Map<WareHouseDto>(WareHouse);
            return CreateActionResult(CustomResponseDto<WareHouseDto>.Success(200, WareHouseDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(WareHouseDto WareHouseDto)
        {
            var WareHouse = await _service.AddAsync(_mapper.Map<WareHouse>(WareHouseDto));
            var WareHousesDto = _mapper.Map<WareHouseDto>(WareHouse);
            return CreateActionResult(CustomResponseDto<WareHouseDto>.Success(201, WareHousesDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(WareHouseDto WareHouseDto)
        {
            await _service.UpdateAsync(_mapper.Map<WareHouse>(WareHouseDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var WareHouse = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(WareHouse);
            return CreateActionResult(CustomResponseDto<List<NoContentDto>>.Success(204));
        }

    }
}
