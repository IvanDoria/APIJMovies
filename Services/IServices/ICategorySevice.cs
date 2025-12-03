using APIJMovies.DAL.Models;
using APIJMovies.DAL.Models.Dtos;

namespace APIJMovies.Services.IServices
{
    public interface ICategorySevice
    {
        Task<ICollection<CategoryDto>> GetCategoriesAsync();
        Task<CategoryDto> GetCategoryAsync(int Id);
        Task<bool> CategoryExistsByIdAsync(int Id);
        Task<bool> CategoryExistsByNameAsync(string Name);
        Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto categoryDto);
        Task<CategoryDto> UpdateCategoryAsync(int id, Category categoryDto);
        Task<bool> DeleteCategoryAsync(int Id);
    }
}
