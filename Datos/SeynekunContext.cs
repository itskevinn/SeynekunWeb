using Entity;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class SeynekunContext : DbContext
    {
        public SeynekunContext(DbContextOptions options) : base(options) { }

        public DbSet<AjusteInventario> AjusteInventarios { get; set; }
        public DbSet<MateriaPrima> MateriasPrimas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Productor> Productores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Bodega> Bodegas { get; set; }
        public DbSet<MateriaPrima> MateriasPrimas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        
    }
}
