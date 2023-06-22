using HospitalManagement.Core.DTOs;

namespace HospitalManagement.Web.Services
{
    public class WarehouseApiService
    {
        private readonly HttpClient _httpClient;

        public WarehouseApiService(HttpClient httpClient)
        {

            _httpClient = httpClient;
        }
        public async Task<List<WarehouseWithBuildingDto>> GetRoomsWithBuildingAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<WarehouseWithBuildingDto>>>("Warehouses/GetWarehousesWithBuilding");

            return response.Data;
        }
        public async Task<List<WarehouseDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<WarehouseDto>>>("Warehouses");
            return response.Data;
        }
        public async Task<WarehouseDto> GetByIdAsync(int id)
        {

            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<WarehouseDto>>($"Warehouses/{id}");
            return response.Data;

        }

        public async Task<WarehouseDto> SaveAsync(WarehouseDto newWarehouse)
        {
            var response = await _httpClient.PostAsJsonAsync("Warehouses", newWarehouse);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<WarehouseDto>>();

            return responseBody.Data;


        }
        public async Task<bool> UpdateAsync(WarehouseDto newWarehouse)
        {
            var response = await _httpClient.PutAsJsonAsync("Warehouses", newWarehouse);

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Warehouses/{id}");

            return response.IsSuccessStatusCode;
        }



    }
}
