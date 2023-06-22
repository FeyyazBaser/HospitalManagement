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
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository) : base(repository, unitOfWork)
        {

            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<CustomResponseDto<List<ProductWithWarehouseDto>>> GetProductsWithWarehouse()
        {
            var products= await _productRepository.GetProductsWithWarehouse();

            var productsDto=_mapper.Map<List<ProductWithWarehouseDto>>(products);

            return CustomResponseDto<List<ProductWithWarehouseDto>>.Success(200,productsDto);
        }
    }
}
