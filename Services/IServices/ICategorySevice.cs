using APIJMovies.API.DAL.Models.Dtos;
using PRACTICA.API.DAL.Models;

namespace APIJMovies.API.Services.IServices
{
    public interface ICategorySevice
    {
        Task<ICollection<CategoryDto>> GetCategoriesAsync();
        Task<CategoryDto> GetCategoryAsync(int Id);
        Task<bool> CategoryExistsByIdAsync(int Id);
        Task<bool> CategoryExistsByNameAsync(string Name);
        Task<bool> CreateCategoryAsync(Category category);
        Task<bool> UpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(int Id);
    }
}
