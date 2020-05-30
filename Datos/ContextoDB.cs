using Entity;
using Microsoft.EntityFrameworkCore;
namespace Datos
{
    public class ContextoDB : DbContext
    {
        public ContextoDB(DbContextOptions options) : base(options)
        {
        }
        public DbSet<AjusteInventario> AjusteInventarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<MateriaPrima> MateriasPrimas { get; set; }

    }
}