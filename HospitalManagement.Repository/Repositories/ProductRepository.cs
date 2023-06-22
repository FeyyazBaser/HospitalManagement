﻿using HospitalManagement.Core.Entities;
using HospitalManagement.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) :base(context)
        {

        }
        public async Task<List<Product>> GetProductsWithWarehouse()
        {
            return await _context.Products.Include(x => x.Warehouse).ToListAsync();
        }
    }
}
