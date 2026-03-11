using Microsoft.AspNetCore.Mvc;
using MyShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;

namespace MyShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailNameFeatureComponentPartial : ViewComponent
    {
        IHttpClientFactory _httpClientFactory;
        public _ProductDetailNameFeatureComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Products/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
