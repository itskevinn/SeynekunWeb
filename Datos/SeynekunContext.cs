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
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Insumo> Insumos { get; set; }
        public DbSet<FichaTecnica> FichasTecnicas { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
    }
}
