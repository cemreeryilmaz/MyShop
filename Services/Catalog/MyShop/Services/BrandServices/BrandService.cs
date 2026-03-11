using AutoMapper;
using MongoDB.Driver;
using MyShop.Catalog.Dtos.BrandDtos;
using MyShop.Catalog.Entities;
using MyShop.Settings;

namespace MyShop.Catalog.Services.BrandServices
{
    public class BrandService:IBrandService
    {
        IMongoCollection<Brand> _brandCollection;
        IMapper _mapper;

        public BrandService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
            _mapper = mapper;
        }

        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            var value = _mapper.Map<Brand>(createBrandDto);
            await _brandCollection.InsertOneAsync(value);
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _brandCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultBrandDto>> GetAllBrandAsync()
        {
            var values = await _brandCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultBrandDto>>(values);
        }

        public async Task<GetByIdBrandDto> GetByIdBrandAsync(string id)
        {
            var values = await _brandCollection.Find<Brand>(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdBrandDto>(values);
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            var values = _mapper.Map<Brand>(updateBrandDto);
            await _brandCollection.FindOneAndReplaceAsync(x => x.Id == updateBrandDto.Id, values);
        }
    }
}
