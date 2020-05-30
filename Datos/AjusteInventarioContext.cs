using Entity;
using Microsoft.EntityFrameworkCore;
namespace Datos
{
    public class AjusteInventarioContext : DbContext
    {
        public AjusteInventarioContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<AjusteInventario> AjusteInventarios { get; set; }

    }
}