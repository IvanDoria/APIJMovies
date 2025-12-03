using APIJMovies.DAL.Models.Dtos;
using APIJMovies.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace APIJMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategorySevice _categoryService;
        public CategoriesController(ICategorySevice categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet(Name = "GetCategoriesAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<CategoryDto>>> GetCategoriesAsync()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            return Ok(categories); // Devuelve un código 200 OK con la lista de categorías
        }

        [HttpGet("{id:int}", Name = "GetCategoryAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoryDto>> GetCategoryAsync(int id)
        {
            var categoryDto = await _categoryService.GetCategoryAsync(id);
            return Ok(categoryDto); // Devuelve un código 200 OK con la lista de categorías
        }

        [HttpPost(Name = "CreateCategoryAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<CategoryDto>> CreateCategoryAsync([FromBody] CategoryCreateDto categoryCreateDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Devuelve un código 400 Bad Request si el modelo no es válido
            }

            try
            {
                var createdCategory = await _categoryService.CreateCategoryAsync(categoryCreateDto);

                // Devuelve un código 201 Created con la categoría creada
                return CreatedAtRoute(
                        "GetCategoryAsync",  // Nombre de la ruta para obtener la categoría creada
                        new { id = createdCategory.Id },  // Parámetros de la ruta
                        createdCategory);  //Objeto de la categoría creada


            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("Ya existe una categoria"))
            {
                return Conflict(ex.Message); // Devuelve un código 409 Conflict si la categoría ya existe
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
