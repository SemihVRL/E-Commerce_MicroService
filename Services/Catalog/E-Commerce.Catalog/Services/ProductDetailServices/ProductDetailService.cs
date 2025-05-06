
using AutoMapper;
using E_Commerce.Catalog.Dtos.ProductDetailDtos;
using E_Commerce.Catalog.Entities;
using E_Commerce.Catalog.Settings;
using MongoDB.Driver;

namespace E_Commerce.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _productdetailcollection;
        private readonly IMapper _mapper;

        public ProductDetailService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productdetailcollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }
        // return döndürüceğin methodlarla(getbyıd and result) await ile ilk kaydet sonra göster
        //return döndürmediğin methodlarda ilk göster sonra await ile kaydet 
        //update ve createte veri tabanını yazarız maplere
        //onun haricindekilere dto yazarız
        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var values=_mapper.Map<ProductDetail>(createProductDetailDto);
            await _productdetailcollection.InsertOneAsync(values);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productdetailcollection.DeleteOneAsync(x => x.ProductDetailID == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var values = await _productdetailcollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(values);
        }

        public  async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var values =await _productdetailcollection.Find<ProductDetail>(x => x.ProductDetailID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(values);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var values=_mapper.Map<ProductDetail>(updateProductDetailDto);
            await _productdetailcollection.FindOneAndReplaceAsync(x => x.ProductDetailID == updateProductDetailDto.ProductDetailID,values);
        }
    }
}
