using APIJMovies.API.DAL.Models.Dtos;
using APIJMovies.API.Repository.IRepository;
using APIJMovies.API.Services.IServices;
using AutoMapper;
using PRACTICA.API.DAL.Models;

namespace APIJMovies.API.Services
{
    public class CategoryService : ICategorySevice
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<bool> CategoryExistsByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CategoryExistsByNameAsync(string Name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteCategoryAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetCategoriesAsync(); // Llamada al repositorio para obtener las categorías 
            return _mapper.Map<ICollection<CategoryDto>>(categories);        //  Mapeo de las categorías a DTOs
        }


        public async Task<CategoryDto> GetCategoryAsync(int Id)
        {
            var category = await _categoryRepository.GetCategoryAsync(Id); // Llamada al repositorio para obtener una categorías 
            return _mapper.Map<CategoryDto>(category);        // Mapeo de la categoría a DTO
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
