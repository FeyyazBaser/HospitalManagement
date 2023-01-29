using HospitalManagement.Core.DTOs;
using HospitalManagement.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalManagement.Web.Controllers
{
    public class WareHousesController : Controller
    {
        private readonly WareHouseApiService _wareHouseApiService;
        private readonly BuildingApiService _buildingApiService;
       

        public WareHousesController(WareHouseApiService wareHouseApiService,BuildingApiService buildingApiService)
        {
            _wareHouseApiService = wareHouseApiService; 
            _buildingApiService = buildingApiService;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _wareHouseApiService.GetAllAsync());
        }

        public async Task<IActionResult> Save()
        {
            var buildingsDto = await _buildingApiService.GetAllAsync();

            ViewBag.buildings = new SelectList(buildingsDto, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(WareHouseDto wareHouseDto)

        {

            if (ModelState.IsValid)
            {
                await _wareHouseApiService.SaveAsync(wareHouseDto);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        public async Task<IActionResult> Update(int id)
        {
            var building = await _wareHouseApiService.GetByIdAsync(id);

            var buildingsDto = await _buildingApiService.GetAllAsync();

            ViewBag.buildings = new SelectList(buildingsDto, "Id", "Name");

            return View(building);

        }
        [HttpPost]
        public async Task<IActionResult> Update(WareHouseDto wareHouseDto)
        {
            if (ModelState.IsValid)
            {

                await _wareHouseApiService.UpdateAsync(wareHouseDto);

                return RedirectToAction(nameof(Index));

            }

            var buildingsDto = await _wareHouseApiService.GetAllAsync();
            return View(buildingsDto);

        }


        public async Task<IActionResult> Remove(int id)
        {
            await _wareHouseApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
