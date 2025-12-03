using Microsoft.EntityFrameworkCore;
using PRACTICA.API.DAL.Models;

namespace APIJMovies.API.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        //Secció de Db Sets

        public DbSet<Category> Categories { get; set; }

    }
}
