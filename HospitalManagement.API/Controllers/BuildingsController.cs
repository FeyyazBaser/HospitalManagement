using AutoMapper;
using HospitalManagement.Core.DTOs;
using HospitalManagement.Core.Entities;
using HospitalManagement.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BuildingsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Building> _service;
        public BuildingsController(IService<Building> service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var Buildings = await _service.GetAllAsync();
            var BuildingDtos = _mapper.Map<List<BuildingDto>>(Buildings.ToList());
            return CreateActionResult(CustomResponseDto<List<BuildingDto>>.Success(200, BuildingDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Building = await _service.GetByIdAsync(id);
            var BuildingDto = _mapper.Map<BuildingDto>(Building);
            return CreateActionResult(CustomResponseDto<BuildingDto>.Success(200, BuildingDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(BuildingDto BuildingDto)
        {
            var Building = await _service.AddAsync(_mapper.Map<Building>(BuildingDto));
            var BuildingsDto = _mapper.Map<BuildingDto>(Building);
            return CreateActionResult(CustomResponseDto<BuildingDto>.Success(201, BuildingsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(BuildingDto BuildingDto)
        {
            await _service.UpdateAsync(_mapper.Map<Building>(BuildingDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var Building = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(Building);
            return CreateActionResult(CustomResponseDto<List<NoContentDto>>.Success(204));
        }
    }
}
