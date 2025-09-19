using AutoMapper;
using MongoDB.Driver;
using MyShop.Catalog.Dtos.ProductDto;
using MyShop.Dtos.ProductDto;
using MyShop.Entities;
using MyShop.Settings;

namespace MyShop.Services.ProductServices
{
    public class ProductService : IProductService
    {
        IMapper _mapper;
        IMongoCollection<Product> _productCollection;
        IMongoCollection<Category> _categoryCollection;
        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
        }

        public async Task CreateProductAsync(CreateProductDto createproductDto)
        {
            var values = _mapper.Map<Product>(createproductDto);
            await _productCollection.InsertOneAsync(values);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var values = await _productCollection.Find<Product>(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(values);
        }

        public async Task<List<ResultProductsWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            foreach (var item in values)
            {
                item.Category = await _categoryCollection.Find<Category>(x => x.Id == item.CategoryId).FirstAsync();
                
            }
            return _mapper.Map<List<ResultProductsWithCategoryDto>>(values);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.Id == updateProductDto.Id, values);
        }
    }
}
