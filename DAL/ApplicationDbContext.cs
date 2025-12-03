using APIJMovies.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace APIJMovies.DAL
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
