using System.ComponentModel.DataAnnotations;

namespace APIJMovies.DAL.Models.Dtos
{
    public class CategoryCreateDto
    {
        [Required(ErrorMessage = "El nombre de la categoria es obligatorio")]
        [Display(Name = "Nombre de la categoría")]
        [MaxLength(100, ErrorMessage = "El nombre de la categoría no puede superar los 100 caracteres")]
        public string Name { get; set; }
    }
}
