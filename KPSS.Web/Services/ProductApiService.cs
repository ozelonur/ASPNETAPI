using KPSS.Core.DTOs;

namespace KPSS.Web.Services
{
    public class ProductApiService
    {
        private readonly HttpClient _client;

        public ProductApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<ProductWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            CustomResponseDto<List<ProductWithCategoryDto>> response =
                await _client.GetFromJsonAsync<CustomResponseDto<List<ProductWithCategoryDto>>>(
                    "products/GetProductsWithCategory");

            return response.Data;
        }

        public async Task<ProductDto> SaveAsync(ProductDto newProduct)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("products", newProduct);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            CustomResponseDto<ProductDto> responseBody =
                await response.Content.ReadFromJsonAsync<CustomResponseDto<ProductDto>>();

            return responseBody.Data;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            CustomResponseDto<ProductDto> response =
                await _client.GetFromJsonAsync<CustomResponseDto<ProductDto>>($"products/{id}");
            return response.Data;
        }

        public async Task<bool> UpdateAsync(ProductDto productDto)
        {
            HttpResponseMessage response = await _client.PutAsJsonAsync("products", productDto);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"products/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}