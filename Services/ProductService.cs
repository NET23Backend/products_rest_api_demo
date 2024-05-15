using System;
namespace products_webb_app.Services
{
	public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductDTO>> GetProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ProductDTO>>("Product");
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"Product/{id}");
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            var response = await _httpClient.PostAsJsonAsync("Product", product);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Product>();
        }

        public async Task<HttpResponseMessage> UpdateProductAsync(int id, Product product)
        {
            return await _httpClient.PutAsJsonAsync($"Product/{id}", product);
        }

        public async Task<HttpResponseMessage> DeleteProductAsync(int id)
        {
            return await _httpClient.DeleteAsync($"Product/{id}");
        }
    }
}

