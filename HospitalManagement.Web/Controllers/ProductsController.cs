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
        private readonly WareHouseApiService _warehouseApiService;
       

        public ProductsController(WareHouseApiService warehouseApiService, ProductApiService productApiService)
        {
            _warehouseApiService = warehouseApiService;
            _productApiService = productApiService;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _productApiService.GetProductsWithCategoryAsync());
        }

        public async Task<IActionResult> Save()
        {
            var warehousesDto = await _warehouseApiService.GetAllAsync();

            ViewBag.warehouses = new SelectList(warehousesDto, "Id", "Name");

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

            var warehousesDto = await _warehouseApiService.GetAllAsync();

            ViewBag.warehouses = new SelectList(warehousesDto, "Id", "Name");
            return View();
        }

   
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productApiService.GetByIdAsync(id);


            var warehousesDto = await _warehouseApiService.GetAllAsync();


            ViewBag.warehouses = new SelectList(warehousesDto, "Id", "Name", product.WareHouseId);

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

            var warehousesDto = await _warehouseApiService.GetAllAsync();



            ViewBag.warehouses = new SelectList(warehousesDto, "Id", "Name", productDto.WareHouseId);

            return View(productDto);

        }


        public async Task<IActionResult> Remove(int id)
        {
            await _productApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
