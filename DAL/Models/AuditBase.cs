using System.ComponentModel.DataAnnotations;

namespace APIJMovies.DAL.Models
{
    public class AuditBase
    {
        [Key]
        public int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; }  

        public virtual DateTime? ModifiedDate { get; set; }
    }
}
