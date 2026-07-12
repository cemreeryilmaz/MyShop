using MyShop.DtoLayer.CatalogDtos.BrandDtos;

namespace MyShop.WebUI.Services.CatalogServices.BrandServices
{
    public class BrandService : IBrandService
    {
        HttpClient _httpClient;

        public BrandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            var response = await _httpClient.PostAsJsonAsync("Brands", createBrandDto);
            await EnsureSuccessAsync(response, "Marka eklenemedi");
        }

        public async Task DeleteBrandAsync(string id)
        {
            var response = await _httpClient.DeleteAsync("Brands?id=" + id);
            await EnsureSuccessAsync(response, "Marka silinemedi");
        }

        public async Task<List<ResultBrandDto>> GetAllBrandAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Brands");
            return await ReadJsonAsync<List<ResultBrandDto>>(responseMessage, "Marka listesi alınamadı")
                ?? new List<ResultBrandDto>();
        }

        public async Task<UpdateBrandDto> GetByIdBrandAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("Brands/" + id);
            return await ReadJsonAsync<UpdateBrandDto>(responseMessage, "Marka bulunamadı")
                ?? throw new InvalidOperationException("Marka bulunamadı.");
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            var response = await _httpClient.PutAsJsonAsync("Brands", updateBrandDto);
            await EnsureSuccessAsync(response, "Marka güncellenemedi");
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
