using MyShop.DtoLayer.CatalogDtos.ProductDtos;

namespace MyShop.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService : IProductService
    {
        HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductAsync(CreateProductDto createproductDto)
        {
            var response = await _httpClient.PostAsJsonAsync("Products", createproductDto);
            await EnsureSuccessAsync(response, "Ürün eklenemedi");
        }

        public async Task DeleteProductAsync(string id)
        {
            var response = await _httpClient.DeleteAsync("Products?id=" + id);
            await EnsureSuccessAsync(response, "Ürün silinemedi");
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Products");
            return await ReadJsonAsync<List<ResultProductDto>>(responseMessage, "Ürün listesi alınamadı")
                ?? new List<ResultProductDto>();
        }

        public async Task<UpdateProductDto> GetByIdProductAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("Products/" + id);
            return await ReadJsonAsync<UpdateProductDto>(responseMessage, "Ürün bulunamadı")
                ?? throw new InvalidOperationException("Ürün bulunamadı.");
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var response = await _httpClient.PutAsJsonAsync("Products", updateProductDto);
            await EnsureSuccessAsync(response, "Ürün güncellenemedi");
        }

        private static async Task EnsureSuccessAsync(HttpResponseMessage response, string message)
        {
            if (response.IsSuccessStatusCode)
            {
                return;
            }

            var body = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException(
                $"{message}. Status: {(int)response.StatusCode} {response.ReasonPhrase}. Body: {body}");
        }

        private static async Task<T?> ReadJsonAsync<T>(HttpResponseMessage response, string message)
        {
            var body = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(
                    $"{message}. Status: {(int)response.StatusCode} {response.ReasonPhrase}. Body: {body}");
            }

            if (string.IsNullOrWhiteSpace(body))
            {
                return default;
            }

            return System.Text.Json.JsonSerializer.Deserialize<T>(body, new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Products");
            return await ReadJsonAsync<List<ResultProductWithCategoryDto>>(responseMessage, "Ürün listesi alınamadı")
                ?? new List<ResultProductWithCategoryDto>();
        }

        public Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
