using AutoMapper;
using HospitalManagement.Core.DTOs;
using HospitalManagement.Core.Entities;
using HospitalManagement.Core.Service;
using HospitalManagement.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehousesController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Warehouse> _service;
        private readonly IWarehouseService _WarehouseService;
        public WarehousesController(IService<Warehouse> service, IMapper mapper,IWarehouseService WarehouseService)
        {
            _WarehouseService=WarehouseService;
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var Warehouses = await _service.GetAllAsync();
            var WarehouseDtos = _mapper.Map<List<WarehouseDto>>(Warehouses.ToList());
            return CreateActionResult(CustomResponseDto<List<WarehouseDto>>.Success(200, WarehouseDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Warehouse = await _service.GetByIdAsync(id);
            var WarehouseDto = _mapper.Map<WarehouseDto>(Warehouse);
            return CreateActionResult(CustomResponseDto<WarehouseDto>.Success(200, WarehouseDto));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetWarehousesWithBuilding()
        {
            return CreateActionResult(await _WarehouseService.GetWarehousesWithBuilding());
        }

        [HttpPost]
        public async Task<IActionResult> Save(WarehouseDto WarehouseDto)
        {
            var Warehouse = await _service.AddAsync(_mapper.Map<Warehouse>(WarehouseDto));
            var WarehousesDto = _mapper.Map<WarehouseDto>(Warehouse);
            return CreateActionResult(CustomResponseDto<WarehouseDto>.Success(201, WarehousesDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(WarehouseDto WarehouseDto)
        {
            await _service.UpdateAsync(_mapper.Map<Warehouse>(WarehouseDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var Warehouse = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(Warehouse);
            return CreateActionResult(CustomResponseDto<List<NoContentDto>>.Success(204));
        }

    }
}
