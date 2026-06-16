using MyShop.DtoLayer.CatalogDtos.CategoryDtos;

namespace MyShop.WebUI.Services.CatalogServices.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createcategoryDto)
        {
            var response = await _httpClient.PostAsJsonAsync("Categories", createcategoryDto);
            await EnsureSuccessAsync(response, "Kategori eklenemedi");
        }

        public async Task DeleteCategoryAsync(string id)
        {
            var response = await _httpClient.DeleteAsync("Categories?id=" + id);
            await EnsureSuccessAsync(response, "Kategori silinemedi");
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Categories");
            return await ReadJsonAsync<List<ResultCategoryDto>>(responseMessage, "Kategori listesi alınamadı")
                ?? new List<ResultCategoryDto>();
        }

        public async Task<UpdateCategoryDto> GetByIdCategoryAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("Categories/" + id);
            return await ReadJsonAsync<UpdateCategoryDto>(responseMessage, "Kategori bulunamadı")
                ?? throw new InvalidOperationException("Kategori bulunamadı.");
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var response = await _httpClient.PutAsJsonAsync("Categories", updateCategoryDto);
            await EnsureSuccessAsync(response, "Kategori güncellenemedi");
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
    }
}
