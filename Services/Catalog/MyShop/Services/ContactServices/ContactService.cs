using AutoMapper;
using MongoDB.Driver;
using MyShop.Catalog.Dtos.ContactDtos;
using MyShop.Catalog.Entities;
using MyShop.Settings;

namespace MyShop.Catalog.Services.ContactServices
{
    public class ContactService : IContactService
    {
        IMongoCollection<Contact> _contactCollection;
        IMapper _mapper;

        public ContactService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _contactCollection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);
            _mapper = mapper;
        }

        public async Task CreateContactAsync<CreateContactDto>(CreateContactDto createContactDto)
        {
            var value = _mapper.Map<Contact>(createContactDto);
            await _contactCollection.InsertOneAsync(value);
        }

        public async Task DeleteContactAsync(string id)
        {
           await _contactCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            var values = await _contactCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultContactDto>>(values);
        }

        public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
        {
            var value = await _contactCollection.Find<Contact>(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdContactDto>(value);
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            var value = _mapper.Map<Contact>(updateContactDto);
            await _contactCollection.ReplaceOneAsync(x => x.Id == updateContactDto.Id, value);
        }
    }
}
