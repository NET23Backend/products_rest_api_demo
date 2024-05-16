using System;
using REST_API_Products.Models;

namespace products_webb_app.Services
{

    // en service är viktig i en applikation för att hantera kommunikation med externa API:er av flera skäl
    // 1. återanvändbarhet: genom att samla API-anropen i en separat klass blir koden mer organiserad och lättare att underhålla

    // 2. separation of concerns: det separerar logiken för att hantera HTTP-anrop från resten av applikationslogiken,
    // vilket gör koden mer modulär och lättare att förstå.

    // 3. testbarhet: genom att använda en service klass kan man enkelt mocka HTTP-anropen i enhetstester,
    // vilket gör det enklare att testa applikationens logik utan att behöva göra faktiska HTTP-anrop.

    // 4. hantera fel: det ger en central plats för att hantera fel och undantag som kan uppstå under HTTP-anrop, vilket gör felhanteringen mer enhetlig.

    // en sån här Service klass kan vi också ha i vårt API, det jag talade om idag var att jag brukar ha det om jag har end points
    // som innehåller mycket logik
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        // det här är konstruktorn för klassen. den tar en HttpClient som parameter och tilldelar den till fältet _httpClient.
        // HttpClient används för att skicka HTTP-förfrågningar och ta emot HTTP-svar från ett API.
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
            // returnerar ett HttpResponseMessage som innehåller statusen för uppdateringen.
        }

        public async Task<HttpResponseMessage> DeleteProductAsync(int id)
        {
            return await _httpClient.DeleteAsync($"Product/{id}");
        }
    }
}

