using AutoMapper;
using HospitalManagement.Core.DTOs;
using HospitalManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Service.Mapping
{
    public class MapProfile :Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<WareHouse,WareHouseDto>().ReverseMap();
            CreateMap<Room,RoomDto>().ReverseMap();
            CreateMap<Building,BuildingDto>().ReverseMap();
            CreateMap<Product,ProductWithWareHouseDto>().ReverseMap();
            CreateMap<WareHouse,WareHouseWithBuildingDto>().ReverseMap();
            CreateMap<Room,RoomWithBuildingDto>().ReverseMap();

        }
    }
}
