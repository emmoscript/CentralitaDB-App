using CentralitaDB_App.Models;
using Microsoft.EntityFrameworkCore;

namespace CentralitaDB_App.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSet para la entidad Llamada
        public DbSet<Llamada> Llamadas { get; set; }
    }
}

