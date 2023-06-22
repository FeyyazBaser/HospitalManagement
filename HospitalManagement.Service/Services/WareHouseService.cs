using AutoMapper;
using HospitalManagement.Core.DTOs;
using HospitalManagement.Core.Entities;
using HospitalManagement.Core.Repositories;
using HospitalManagement.Core.Service;
using HospitalManagement.Core.UnitOfWorks;
using HospitalManagement.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Service.Services
{
    public class WarehouseService : Service<Warehouse>, IWarehouseService
    {
        private readonly IWarehouseRepository _WarehouseRepository;
        private readonly IMapper _mapper;

        public WarehouseService(IGenericRepository<Warehouse> repository, IUnitOfWork unitOfWork,IMapper mapper, IWarehouseRepository WarehouseRepository) : base(repository, unitOfWork)
        {
            _WarehouseRepository = WarehouseRepository;
            _mapper = mapper;
        }
        public async Task<CustomResponseDto<List<WarehouseWithBuildingDto>>> GetWarehousesWithBuilding()
        {
            var Warehouses = await _WarehouseRepository.GetWarehousesWithBuilding();

            var WarehousesDto = _mapper.Map<List<WarehouseWithBuildingDto>>(Warehouses);

            return CustomResponseDto<List<WarehouseWithBuildingDto>>.Success(200, WarehousesDto);
        }

    }
}
