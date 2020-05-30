using Entity;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class SeynekunContext : DbContext
    {
        public SeynekunContext(DbContextOptions options) : base(options) { }

        public DbSet<AjusteInventario> AjusteInventarios { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Productor> Productores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
