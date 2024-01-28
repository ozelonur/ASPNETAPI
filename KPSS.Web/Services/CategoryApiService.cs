using KPSS.Core.DTOs;

namespace KPSS.Web.Services
{
    public class CategoryApiService
    {
        private readonly HttpClient _client;

        public CategoryApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            CustomResponseDto<List<CategoryDto>> response = await _client.GetFromJsonAsync<CustomResponseDto<List<CategoryDto>>>("categories");

            return response.Data;
        }
     }
}

