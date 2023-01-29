using HospitalManagement.Core.DTOs;
using HospitalManagement.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalManagement.Web.Controllers
{
    public class RoomsController : Controller
    {
        private readonly RoomApiService _roomApiService;
        private readonly BuildingApiService _buildingApiService;


        public RoomsController(RoomApiService roomApiService, BuildingApiService buildingApiService)
        {
            _roomApiService = roomApiService;
            _buildingApiService = buildingApiService;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _roomApiService.GetAllAsync());
        }

        public async Task<IActionResult> Save()
        {
            var buildingsDto = await _buildingApiService.GetAllAsync();

            ViewBag.buildings = new SelectList(buildingsDto, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(RoomDto roomDto)

        {

            if (ModelState.IsValid)
            {
                await _roomApiService.SaveAsync(roomDto);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        public async Task<IActionResult> Update(int id)
        {
            var building = await _roomApiService.GetByIdAsync(id);

            var buildingsDto = await _buildingApiService.GetAllAsync();

            ViewBag.buildings = new SelectList(buildingsDto, "Id", "Name");

            return View(building);

        }
        [HttpPost]
        public async Task<IActionResult> Update(RoomDto roomDto)
        {
            if (ModelState.IsValid)
            {

                await _roomApiService.UpdateAsync(roomDto);

                return RedirectToAction(nameof(Index));

            }

            var buildingsDto = await _roomApiService.GetAllAsync();
            return View(buildingsDto);

        }


        public async Task<IActionResult> Remove(int id)
        {
            await _roomApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
