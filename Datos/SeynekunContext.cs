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
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<FichaTecnica> FichasTecnicas { get; set; }
        public DbSet<Insumo> Insumos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleVenta> DetallesVentas { get; set; }
        public DbSet<Produccion> Producciones { get; set; }
        public DbSet<Transportador> Transportadores { get; set; }
        public DbSet<Control> Controles { get; set; }
    }
}
