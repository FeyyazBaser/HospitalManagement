using HospitalManagement.Core.DTOs;
using System.Collections.Generic;

namespace HospitalManagement.Web.Services
{
    public class BuildingApiService
    {
        private readonly HttpClient _httpClient;

        public BuildingApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<BuildingDto>> GetAllAsync()
        {

            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<BuildingDto>>>($"buildings");
            return response.Data;

        }

        public async Task<BuildingDto> GetByIdAsync(int id)
        {

            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<BuildingDto>>($"buildings/{id}");
            return response.Data;

        }

        public async Task<BuildingDto> SaveAsync(BuildingDto newBuilding)
        {
            var response = await _httpClient.PostAsJsonAsync("buildings", newBuilding);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<BuildingDto>>();

            return responseBody.Data;


        }
        public async Task<bool> UpdateAsync(BuildingDto newBuilding)
        {
            var response = await _httpClient.PutAsJsonAsync("buildings", newBuilding);

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"buildings/{id}");

            return response.IsSuccessStatusCode;
        }

    }
}
