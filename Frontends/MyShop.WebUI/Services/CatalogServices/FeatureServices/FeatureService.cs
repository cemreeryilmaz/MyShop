using MyShop.DtoLayer.CatalogDtos.FeatureDtos;

namespace MyShop.WebUI.Services.CatalogServices.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        HttpClient _httpClient;

        public FeatureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            var response = await _httpClient.PostAsJsonAsync("Features", createFeatureDto);
            await EnsureSuccessAsync(response, "Kategori eklenemedi");
        }

        public async Task DeleteFeatureAsync(string id)
        {
            var response = await _httpClient.DeleteAsync("Features?id=" + id);
            await EnsureSuccessAsync(response, "Kategori silinemedi");
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Features");
            return await ReadJsonAsync<List<ResultFeatureDto>>(responseMessage, "Kategori listesi alınamadı")
                ?? new List<ResultFeatureDto>();
        }

        public async Task<UpdateFeatureDto> GetByIdFeatureAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("Features/" + id);
            return await ReadJsonAsync<UpdateFeatureDto>(responseMessage, "Kategori bulunamadı")
                ?? throw new InvalidOperationException("Kategori bulunamadı.");
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
        {
            var response = await _httpClient.PutAsJsonAsync("Features", updateFeatureDto);
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
