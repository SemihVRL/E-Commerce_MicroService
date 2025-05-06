using AutoMapper;
using E_Commerce.Catalog.Dtos.ProductDtos;
using E_Commerce.Catalog.Entities;
using E_Commerce.Catalog.Settings;
using MongoDB.Driver;

namespace E_Commerce.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productcollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productcollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }
        // return döndürüceğin methodlarla(getbyıd and result) await ile ilk kaydet sonra göster
        //return döndürmediğin methodlarda ilk göster sonra await ile kaydet 
        //update ve createte veri tabanını yazarız maplere
        //onun haricindekilere dto yazarız
        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<Product>(createProductDto);
            await _productcollection.InsertOneAsync(values);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productcollection.DeleteOneAsync(x => x.CategoryID == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _productcollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var values =await _productcollection.Find<Product>(x=>x.ProductID==id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(values);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values=_mapper.Map<Product>(updateProductDto);
            await _productcollection.FindOneAndReplaceAsync(x => x.ProductID == updateProductDto.ProductID, values);
        }
    }
}
