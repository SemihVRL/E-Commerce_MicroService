using AutoMapper;
using E_Commerce.Catalog.Dtos.ProductImageDtos;
using E_Commerce.Catalog.Entities;
using E_Commerce.Catalog.Settings;
using MongoDB.Driver;
using ZstdSharp.Unsafe;

namespace E_Commerce.Catalog.Services.ProductImageServices
{
    public class ProductServiceImage : IProductImageService
    {

        private readonly IMongoCollection<ProductImage> _productımagecollection;
        private readonly IMapper _mapper;

        public ProductServiceImage(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productımagecollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }
        // return döndürüceğin methodlarla(getbyıd and result) await ile ilk kaydet sonra göster
        //return döndürmediğin methodlarda ilk göster sonra await ile kaydet 
        //update ve createte veri tabanını yazarız maplere
        //onun haricindekilere dto yazarız
        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var values = _mapper.Map<ProductImage>(createProductImageDto);//göster
            await _productımagecollection.InsertOneAsync(values);//kaydet

        }

        public async Task DeleteProductImageAsync(string id)
        {
            var values = await _productımagecollection.DeleteOneAsync(x => x.ProductImageID == id);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var values = _mapper.Map<ProductImage>(updateProductImageDto);
            await _productımagecollection.FindOneAndReplaceAsync(x => x.ProductImageID == updateProductImageDto.ProductImageID, values);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var values = await _productımagecollection.Find<ProductImage>(x => x.ProductImageID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(values);
        }

        public async Task<List<ResultProductImageDto>> GetResultProductImageAsync()
        {
            var values = await _productımagecollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

       
    }
}
