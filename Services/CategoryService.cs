using APIJMovies.DAL.Models;
using APIJMovies.DAL.Models.Dtos;
using APIJMovies.Repository.IRepository;
using APIJMovies.Services.IServices;
using AutoMapper;

namespace APIJMovies.Services
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

        public async Task<CategoryDto> CreateCategoryAsync(CategoryCreateDto categoryCreateDto)
        {
            //Validar si la categoría ya existe por nombre
            var categoryExists =await _categoryRepository.CategoryExistsByNameAsync(categoryCreateDto.Name);

            if (categoryExists)
                {
                     throw new InvalidOperationException($"Ya existe una categoria con el nombre de '{categoryCreateDto.Name}'");
                }

            //Mapear el DTO a la entidad Category
            var category = _mapper.Map<Category>(categoryCreateDto);

            //Crear la categoría en el repositorio
            var categoryCreated = await _categoryRepository.CreateCategoryAsync(category);

            if (!categoryCreated)
            {
                throw new Exception("Error al crear la categoría");
            }

            //Mapear la entidad Category a CategoryDto
            return _mapper.Map<CategoryDto>(category);

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

        public async Task<CategoryDto> UpdateCategoryAsync(int id, Category categoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
