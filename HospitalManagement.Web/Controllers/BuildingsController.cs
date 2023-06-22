using HospitalManagement.Core.DTOs;
using HospitalManagement.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalManagement.Web.Controllers
{
    public class BuildingsController : Controller
    {
        private readonly BuildingApiService _buildingApiService;


        string GetToken()
        {
            return HttpContext.Session.GetString("JwtToken");
        }
        public BuildingsController(BuildingApiService buildingApiService)
        {
            _buildingApiService = buildingApiService;


        }


        public async Task<IActionResult> Index()
        {
            _buildingApiService.accessToken = GetToken();
            return View(await _buildingApiService.GetAllAsync());
        }

        public async Task<IActionResult> Save()
        {
            _buildingApiService.accessToken = GetToken();
            var buildingsDto = await _buildingApiService.GetAllAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(BuildingDto buildingDto)

        {

            if (ModelState.IsValid)
            {
                _buildingApiService.accessToken = GetToken();
                await _buildingApiService.SaveAsync(buildingDto);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        public async Task<IActionResult> Update(int id)
        {
            _buildingApiService.accessToken = GetToken();
            var building = await _buildingApiService.GetByIdAsync(id);

            return View(building);

        }
        [HttpPost]
        public async Task<IActionResult> Update(BuildingDto buildingDto)
        {
            if (ModelState.IsValid)
            {
                _buildingApiService.accessToken = GetToken();
                await _buildingApiService.UpdateAsync(buildingDto);

                return RedirectToAction(nameof(Index));

            }

            var buildingsDto = await _buildingApiService.GetAllAsync();
            return View(buildingsDto);

        }


        public async Task<IActionResult> Remove(int id)
        {
            _buildingApiService.accessToken = GetToken();
            await _buildingApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
