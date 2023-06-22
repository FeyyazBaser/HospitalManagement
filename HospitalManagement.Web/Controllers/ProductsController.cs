using HospitalManagement.Core.DTOs;
using HospitalManagement.Core.Entities;
using HospitalManagement.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;

namespace HospitalManagement.Web.Controllers
{
    public class ProductsController : Controller
    {

        private readonly ProductApiService _productApiService;
        private readonly WarehouseApiService _WarehouseApiService;
       

        public ProductsController(WarehouseApiService WarehouseApiService, ProductApiService productApiService)
        {
            _WarehouseApiService = WarehouseApiService;
            _productApiService = productApiService;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _productApiService.GetProductsWithCategoryAsync());
        }

        public async Task<IActionResult> Save()
        {
            var WarehousesDto = await _WarehouseApiService.GetAllAsync();

            ViewBag.Warehouses = new SelectList(WarehousesDto, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)

        {


            if (ModelState.IsValid)
            {

                await _productApiService.SaveAsync(productDto);


                return RedirectToAction(nameof(Index));
            }

            var WarehousesDto = await _WarehouseApiService.GetAllAsync();

            ViewBag.Warehouses = new SelectList(WarehousesDto, "Id", "Name");
            return View();
        }

   
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productApiService.GetByIdAsync(id);


            var WarehousesDto = await _WarehouseApiService.GetAllAsync();


            ViewBag.Warehouses = new SelectList(WarehousesDto, "Id", "Name", product.WarehouseId);

            return View(product);

        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {

                await _productApiService.UpdateAsync(productDto);

                return RedirectToAction(nameof(Index));

            }

            var WarehousesDto = await _WarehouseApiService.GetAllAsync();



            ViewBag.Warehouses = new SelectList(WarehousesDto, "Id", "Name", productDto.WarehouseId);

            return View(productDto);

        }


        public async Task<IActionResult> Remove(int id)
        {
            await _productApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
