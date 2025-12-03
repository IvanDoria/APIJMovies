using PRACTICA.API.DAL.Models;

namespace APIJMovies.API.Repository.IRepository
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetCategoriesAsync(); //Retorno en una colcolección todas las categorías
        Task<Category> GetCategoryAsync(int Id); //Retorno una categoría en función de su Id
        Task<bool> CategoryExistsByIdAsync(int Id); //Compruebo si existe una categoría en función de su Id
        Task<bool> CategoryExistsByNameAsync(string Name); //Compruebo si existe una categoría en función de su Nombre
        Task<bool> CreateCategoryAsync(Category category); //Creo una nueva categoría
        Task<bool> UpdateCategoryAsync(Category category); //Actualizo una categoría existente
        Task<bool> DeleteCategoryAsync(int Id); //Elimino una categoría existente

    }
}
