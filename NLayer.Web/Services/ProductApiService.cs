using NLayer.Core.DTO_s;

namespace NLayer.Web.Services
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;

        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductWithCategoryDto>> GetProductWithCategoryAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<ProductWithCategoryDto>>>("ProductsWithDto/GetProductsWithCategory");

            return response.Data;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<ProductDto>>($"ProductsWithDto/{id}");
            return response.Data;
        }

        public async Task<ProductCreateDto> SaveAsync(ProductCreateDto newProduct)
        {
            var response = await _httpClient.PostAsJsonAsync("ProductsWithDto", newProduct);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<ProductCreateDto>>();

            return responseBody.Data;            
        }

        public async Task<bool> UpdateAsync(ProductUpdateDto newProduct)
        {
            var response = await _httpClient.PutAsJsonAsync("ProductsWithDto", newProduct);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"ProductsWithDto/{id}");

            return response.IsSuccessStatusCode;
        }

    }
}
