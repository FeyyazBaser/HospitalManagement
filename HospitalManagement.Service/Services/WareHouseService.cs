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
    public class WareHouseService : Service<WareHouse>, IWareHouseService
    {
        private readonly IWareHouseRepository _wareHouseRepository;
        private readonly IMapper _mapper;

        public WareHouseService(IGenericRepository<WareHouse> repository, IUnitOfWork unitOfWork,IMapper mapper, IWareHouseRepository wareHouseRepository) : base(repository, unitOfWork)
        {
            _wareHouseRepository = wareHouseRepository;
            _mapper = mapper;
        }
        public async Task<CustomResponseDto<List<WareHouseWithBuildingDto>>> GetWareHousesWithBuilding()
        {
            var wareHouses = await _wareHouseRepository.GetWareHousesWithBuilding();

            var wareHousesDto = _mapper.Map<List<WareHouseWithBuildingDto>>(wareHouses);

            return CustomResponseDto<List<WareHouseWithBuildingDto>>.Success(200, wareHousesDto);
        }

    }
}
