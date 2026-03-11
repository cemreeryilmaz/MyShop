using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DtoLayer.CatalogDtos.BrandDtos
{
    public class UpdateBrandDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
