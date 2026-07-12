using MyShop.DtoLayer.CatalogDtos.AboutDtos;

namespace MyShop.WebUI.Services.CatalogServices.AboutServices
{
    public class AboutService : IAboutService
    {
        HttpClient _httpClient;

        public AboutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            var response = await _httpClient.PostAsJsonAsync("Abouts", createAboutDto);
            await EnsureSuccessAsync(response, "Hakkımızda eklenemedi");
        }

        public async Task DeleteAboutAsync(string id)
        {
            var response = await _httpClient.DeleteAsync("Abouts?id=" + id);
            await EnsureSuccessAsync(response, "Hakkımızda silinemedi");
        }

        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            var responseMessage = await _httpClient.GetAsync("Abouts");
            return await ReadJsonAsync<List<ResultAboutDto>>(responseMessage, "Hakkımızda listesi alınamadı")
                ?? new List<ResultAboutDto>();
        }

        public async Task<UpdateAboutDto> GetByIdAboutAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("Abouts/" + id);
            return await ReadJsonAsync<UpdateAboutDto>(responseMessage, "Hakkımızda bulunamadı")
                ?? throw new InvalidOperationException("Hakkımızda bulunamadı.");
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            var response = await _httpClient.PutAsJsonAsync("Abouts", updateAboutDto);
            await EnsureSuccessAsync(response, "Hakkımızda güncellenemedi");
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
