using System.ComponentModel.DataAnnotations;

namespace PRACTICA.API.DAL.Models
{
    public class AuditBase
    {
        [Key]
        public int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; }  

        public virtual DateTime? ModifiedDate { get; set; }
    }
}
