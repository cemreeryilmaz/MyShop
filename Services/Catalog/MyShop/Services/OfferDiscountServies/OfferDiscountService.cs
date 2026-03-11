using AutoMapper;
using MongoDB.Driver;
using MyShop.Catalog.Dtos.OfferDiscountDtos;
using MyShop.Catalog.Entities;
using MyShop.Entities;
using MyShop.Settings;

namespace MyShop.Catalog.Services.OfferDiscountServies
{
    public class OfferDiscountService : IOfferDiscountService
    {
        IMongoCollection<OfferDiscount> _offerDiscountCollection;
        IMapper _mapper;

        public OfferDiscountService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _offerDiscountCollection = database.GetCollection<OfferDiscount>(_databaseSettings.OfferDiscountCollectionName);
            _mapper = mapper;
        }

        public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
        {
            var value = _mapper.Map<OfferDiscount>(createOfferDiscountDto);
            await _offerDiscountCollection.InsertOneAsync(value);
        }

        public async Task DeleteOfferDiscountAsync(string id)
        {
            await _offerDiscountCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync()
        {
            var values = await _offerDiscountCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultOfferDiscountDto>>(values);
        }

        public async Task<GetByIdOfferDiscountDto> GetByIdOfferDiscountAsync(string id)
        {
            var values = await _offerDiscountCollection.Find<OfferDiscount>(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdOfferDiscountDto>(values);
        }

        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            var values = _mapper.Map<OfferDiscount>(updateOfferDiscountDto);
            await _offerDiscountCollection.FindOneAndReplaceAsync(x => x.Id == updateOfferDiscountDto.Id, values);
        }
    }
}
