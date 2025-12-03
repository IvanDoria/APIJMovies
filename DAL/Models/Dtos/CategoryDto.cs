using System.ComponentModel.DataAnnotations;

namespace APIJMovies.API.DAL.Models.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la categoria es obligatorio")]
        [Display(Name = "Nombre de la categoría")]
        [MaxLength(100, ErrorMessage = "El nombre de la categoría no puede superar los 100 caracteres")]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
