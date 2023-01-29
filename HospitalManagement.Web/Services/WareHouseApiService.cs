using HospitalManagement.Core.DTOs;

namespace HospitalManagement.Web.Services
{
    public class WareHouseApiService
    {
        private readonly HttpClient _httpClient;

        public WareHouseApiService(HttpClient httpClient)
        {

            _httpClient = httpClient;
        }

        public async Task<List<WareHouseDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<WareHouseDto>>>("warehouses");
            return response.Data;
        }
        public async Task<WareHouseDto> GetByIdAsync(int id)
        {

            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<WareHouseDto>>($"warehouses/{id}");
            return response.Data;

        }

        public async Task<WareHouseDto> SaveAsync(WareHouseDto newWarehouse)
        {
            var response = await _httpClient.PostAsJsonAsync("warehouses", newWarehouse);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<WareHouseDto>>();

            return responseBody.Data;


        }
        public async Task<bool> UpdateAsync(WareHouseDto newWarehouse)
        {
            var response = await _httpClient.PutAsJsonAsync("warehouses", newWarehouse);

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"warehouses/{id}");

            return response.IsSuccessStatusCode;
        }



    }
}
