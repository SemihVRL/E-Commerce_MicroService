using E_Commerce.Catalog.Dtos.CategoryDtos;
using E_Commerce.Catalog.Entities;
using E_Commerce.Catalog.Services.CategoryServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace E_Commerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return Ok(values);
            //bize bir şey göstermesi gerektiği için burda var values yaptık
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryByID(string id)
        {
            var values = await _categoryService.GetByIDCategoryAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return Ok("BAŞARIYLA KAYDEDİLDİ");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string id)
        {

            await _categoryService.DeleteCategoryAsync(id);
            return Ok("Başarıyla Silindi");
        }

        [HttpPut]

        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {

            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Başarıyla güncellendi");
        }





    }
}
