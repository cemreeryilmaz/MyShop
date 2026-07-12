using MyShop.DtoLayer.CatalogDtos.OfferDiscountDtos;

namespace MyShop.WebUI.Services.CatalogServices.OfferDiscountServices
{
    public class OfferDiscountService: IOfferDiscountService
    {
        HttpClient _httpClient;

        public OfferDiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
        {
            var response = await _httpClient.PostAsJsonAsync("OfferDiscounts", createOfferDiscountDto);
            await EnsureSuccessAsync(response, "Kategori eklenemedi");
        }

        public async Task DeleteOfferDiscountAsync(string id)
        {
            var response = await _httpClient.DeleteAsync("OfferDiscounts?id=" + id);
            await EnsureSuccessAsync(response, "Kategori silinemedi");
        }

        public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync()
        {
            var responseMessage = await _httpClient.GetAsync("OfferDiscounts");
            return await ReadJsonAsync<List<ResultOfferDiscountDto>>(responseMessage, "Kategori listesi alınamadı")
                ?? new List<ResultOfferDiscountDto>();
        }

        public async Task<UpdateOfferDiscountDto> GetByIdOfferDiscountAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("OfferDiscounts/" + id);
            return await ReadJsonAsync<UpdateOfferDiscountDto>(responseMessage, "Kategori bulunamadı")
                ?? throw new InvalidOperationException("Kategori bulunamadı.");
        }

        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            var response = await _httpClient.PutAsJsonAsync("OfferDiscounts", updateOfferDiscountDto);
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
