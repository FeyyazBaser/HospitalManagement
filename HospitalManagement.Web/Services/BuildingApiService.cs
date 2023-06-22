using HospitalManagement.Core.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace HospitalManagement.Web.Services
{
   
    public class BuildingApiService
    {
        private readonly HttpClient _httpClient;
        public string accessToken;

        public BuildingApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }


        public async Task<List<BuildingDto>> GetAllAsync()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<BuildingDto>>>($"buildings");
            return response.Data;


        }

        public async Task<BuildingDto> GetByIdAsync(int id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<BuildingDto>>($"buildings/{id}");
            return response.Data;

        }

        public async Task<BuildingDto> SaveAsync(BuildingDto newBuilding)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _httpClient.PostAsJsonAsync("buildings", newBuilding);
            UnauthorizedAccessException unauthorizedAccessException = new UnauthorizedAccessException();
            if (!response.IsSuccessStatusCode)
                throw
                 unauthorizedAccessException;


            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<BuildingDto>>();

            return responseBody.Data;


        }
        public async Task<bool> UpdateAsync(BuildingDto newBuilding)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _httpClient.PutAsJsonAsync("buildings", newBuilding);

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var response = await _httpClient.DeleteAsync($"buildings/{id}");

            return response.IsSuccessStatusCode;
        }

    }
}
