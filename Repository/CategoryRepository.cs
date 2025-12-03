using APIJMovies.API.DAL;
using APIJMovies.API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using PRACTICA.API.DAL.Models;

namespace APIJMovies.API.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CategoryExistsByIdAsync(int Id)
        {
            return await _context.Categories
                .AsNoTracking() //Evito el seguimiento de cambios para mejorar el rendimiento
                .AnyAsync(c => c.Id == Id); //Lambda expression para comprobar si existe la categoría por Id de forma asíncrona
        }

        public async Task<bool> CategoryExistsByNameAsync(string Name)
        {
            return await _context.Categories
                .AsNoTracking() //Evito el seguimiento de cambios para mejorar el rendimiento
                .AnyAsync(c => c.Name == Name); //Lambda expression para comprobar si existe la categoría por Name de forma asíncrona
        }

        public async Task<bool> CreateCategoryAsync(Category category)
        {
            category.CreatedDate = DateTime.UtcNow; //Establezco la fecha de creación en UTC
            await _context.Categories.AddAsync(category); //Añado la nueva categoría de forma asíncrona
            return await SaveAsync(); //Guardo los cambios de forma asíncrona

        }

        public async Task<bool> DeleteCategoryAsync(int Id)
        {
            var category = await GetCategoryAsync(Id); //Obtengo la categoría por Id de forma asíncrona

            if (category == null)
            {
                return false; //Si no existe la categoría, retorno false
            }

            _context.Categories.Remove(category);
            return await SaveAsync(); //Guardo los cambios de forma asíncrona

        }

        public async Task<ICollection<Category>> GetCategoriesAsync()
        {
            var categories = await _context.Categories
                .AsNoTracking() //Evito el seguimiento de cambios para mejorar el rendimiento
                .OrderBy(c => c.Name) //Ordenar lista por nombre de categoría
                .ToListAsync(); //Devuelvo la lista de categorías de forma asíncrona

            return categories;

        }

        public async Task<Category> GetCategoryAsync(int Id) 
        {
            return await _context.Categories // async y await
                .AsNoTracking() //Evito el seguimiento de cambios para mejorar el rendimiento
                .FirstOrDefaultAsync(c => c.Id == Id); //Lambda expression para buscar la categoría por Id de forma asíncrona

        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            category.ModifiedDate = DateTime.UtcNow; //Establezco la fecha de creación en UTC
            _context.Categories.Update(category); //Añado la nueva categoría de forma asíncrona
            return await SaveAsync(); //Guardo los cambios de forma asíncrona
        }

        private async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0 ? true : false; //Guardo los cambios de forma asíncrona
        }

    }
}
