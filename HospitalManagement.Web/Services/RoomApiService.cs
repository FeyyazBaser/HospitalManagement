using HospitalManagement.Core.DTOs;

namespace HospitalManagement.Web.Services
{
    public class RoomApiService
    {
        private readonly HttpClient _httpClient;

        public RoomApiService(HttpClient httpClient)
        {

            _httpClient = httpClient;
        }

        public async Task<List<RoomDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<RoomDto>>>("rooms");
            return response.Data;
        }
        public async Task<RoomDto> GetByIdAsync(int id)
        {

            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<RoomDto>>($"rooms/{id}");
            return response.Data;

        }

        public async Task<RoomDto> SaveAsync(RoomDto newRoom)
        {
            var response = await _httpClient.PostAsJsonAsync("rooms", newRoom);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<RoomDto>>();

            return responseBody.Data;


        }
        public async Task<bool> UpdateAsync(RoomDto newRoom)
        {
            var response = await _httpClient.PutAsJsonAsync("rooms", newRoom);

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"rooms/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
