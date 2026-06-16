using MyShop.DtoLayer.CatalogDtos.SpecialOfferDtos;

namespace MyShop.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        HttpClient _httpClient;

        public SpecialOfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            var response = await _httpClient.PostAsJsonAsync("SpecialOffers", createSpecialOfferDto);
            await EnsureSuccessAsync(response, "Kategori eklenemedi");
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            var response = await _httpClient.DeleteAsync("SpecialOffers?id=" + id);
            await EnsureSuccessAsync(response, "Silinemedi");
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {
            var responseMessage = await _httpClient.GetAsync("SpecialOffers");
            return await ReadJsonAsync<List<ResultSpecialOfferDto>>(responseMessage, "Liste Alınamadı")
                ?? new List<ResultSpecialOfferDto>();
        }

        public async Task<UpdateSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("SpecialOffers/" + id);
            return await ReadJsonAsync<UpdateSpecialOfferDto>(responseMessage, "Bulunamadı")
                ?? throw new InvalidOperationException("Bulunamadı.");
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            var response = await _httpClient.PutAsJsonAsync("SpecialOffers", updateSpecialOfferDto);
            await EnsureSuccessAsync(response, "Güncellenemedi");
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
