using MyShop.Dtos.CategoryDto;

namespace MyShop.Catalog.Dtos.ProductDto
{
    public class ResultProductsWithCategoryDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public ResultCategoryDto Category { get; set; }
    }
}
