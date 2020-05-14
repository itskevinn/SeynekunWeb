using Entity;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class MateriaPrimaContext : DbContext
    {
        public MateriaPrimaContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<MateriaPrima> MateriasPrimas { get; set; }
    }
}
