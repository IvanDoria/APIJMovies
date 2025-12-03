using System.ComponentModel.DataAnnotations;

namespace APIJMovies.DAL.Models
{
    public class Category : AuditBase
    {
        [Required]
        [Display(Name = "Nombre de la categoría")]
        public string Name { get; set; }

    }
}
