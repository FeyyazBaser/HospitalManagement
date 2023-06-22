using HospitalManagement.Core.DTOs;
using HospitalManagement.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalManagement.Web.Controllers
{
    public class WarehousesController : Controller
    {
        private readonly WarehouseApiService _WarehouseApiService;
        private readonly BuildingApiService _buildingApiService;
       

        public WarehousesController(WarehouseApiService WarehouseApiService,BuildingApiService buildingApiService)
        {
            _WarehouseApiService = WarehouseApiService; 
            _buildingApiService = buildingApiService;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _WarehouseApiService.GetRoomsWithBuildingAsync());
        }

        public async Task<IActionResult> Save()
        {
            var buildingsDto = await _buildingApiService.GetAllAsync();

            ViewBag.buildings = new SelectList(buildingsDto, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(WarehouseDto WarehouseDto)

        {

            if (ModelState.IsValid)
            {
                await _WarehouseApiService.SaveAsync(WarehouseDto);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        public async Task<IActionResult> Update(int id)
        {
            var building = await _WarehouseApiService.GetByIdAsync(id);

            var buildingsDto = await _buildingApiService.GetAllAsync();

            ViewBag.buildings = new SelectList(buildingsDto, "Id", "Name");

            return View(building);

        }
        [HttpPost]
        public async Task<IActionResult> Update(WarehouseDto WarehouseDto)
        {
            if (ModelState.IsValid)
            {

                await _WarehouseApiService.UpdateAsync(WarehouseDto);

                return RedirectToAction(nameof(Index));

            }

            var buildingsDto = await _WarehouseApiService.GetAllAsync();
            return View(buildingsDto);

        }


        public async Task<IActionResult> Remove(int id)
        {
            await _WarehouseApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
