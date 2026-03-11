using Microsoft.AspNetCore.Mvc;
using MyShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;

namespace MyShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        IHttpClientFactory _httpClientFactory;

        public ProductListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index(string id)
        {
            ViewBag.i = id;
            return View();
        }

        public IActionResult ProductDetail(string id)
        {
            ViewBag.x = id;
            return View();
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(CreateCommentDto createCommentDto)
        {
            return View();
        }
    }
}
