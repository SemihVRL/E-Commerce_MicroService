using E_Commerce.Catalog.Dtos.ProductImageDtos;

namespace E_Commerce.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetResultProductImageAsync();
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string id);

        Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
    }
}
