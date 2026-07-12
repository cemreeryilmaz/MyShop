using MyShop.DtoLayer.CatalogDtos.FeatureSliderDtos;

namespace MyShop.WebUI.Services.CatalogServices.SliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        HttpClient _httpClient;

        public FeatureSliderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            var response = await _httpClient.PostAsJsonAsync("FeatureSliders", createFeatureSliderDto);
            await EnsureSuccessAsync(response, "Kategori eklenemedi");
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            var response = await _httpClient.DeleteAsync("FeatureSliders?id=" + id);
            await EnsureSuccessAsync(response, "Kategori silinemedi");
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            var responseMessage = await _httpClient.GetAsync("FeatureSliders");
            return await ReadJsonAsync<List<ResultFeatureSliderDto>>(responseMessage, "Kategori listesi alınamadı")
                ?? new List<ResultFeatureSliderDto>();
        }

        public async Task<UpdateFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("FeatureSliders/" + id);
            return await ReadJsonAsync<UpdateFeatureSliderDto>(responseMessage, "Kategori bulunamadı")
                ?? throw new InvalidOperationException("Kategori bulunamadı.");
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var response = await _httpClient.PutAsJsonAsync("FeatureSliders", updateFeatureSliderDto);
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

        public Task FeatureSliderChangeStatusToTrue(string id)
        {
            throw new NotImplementedException();
        }

        public Task FeatureSliderChangeStatusToFalse(string id)
        {
            throw new NotImplementedException();
        }
    }
}
