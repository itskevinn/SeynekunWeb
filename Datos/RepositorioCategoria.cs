using System.Collections.Generic;
using System.Data.SqlClient;
using Entity;
namespace Datos
{
    public class RepositorioCategoria
    {
        private readonly SqlConnection _conexión;

        public RepositorioCategoria(GestionadorDeConexión conexión)
        {
            _conexión = conexión._conexion;
        }

        public void Guardar(Categoria categoria)
        {
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = @"Insert Into Categoria (Nombre, Detalle, Estado) values (@Nombre,@Detalle,@Estado)";
                comando.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                comando.Parameters.AddWithValue("@Detalle", categoria.Detalle);
                comando.Parameters.AddWithValue("@Estado", categoria.Estado);                
                var filas = comando.ExecuteNonQuery();
            }
        }

        public List<Categoria> Consultar()
        {
            List<Categoria> categorias = new List<Categoria>();
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "Select * from Categoria";
                var datos = comando.ExecuteReader();
                if (datos.HasRows)
                {
                    while (datos.Read())
                    {
                        categorias.Add(MapToCategoria(datos));
                    }
                }
            }
            return categorias;
        }

        private Categoria MapToCategoria(SqlDataReader datos)
        {
            if (!datos.HasRows) return null;
            Categoria categoria = new Categoria();
            categoria.Nombre = (string)datos["Nombre"];
            categoria.Detalle = (string)datos["Detalle"];
            categoria.Estado = (string)datos["Estado"];
            return categoria;
        }
        public Categoria BuscarxId(string nombre)
        {
            Categoria categoria = new Categoria();
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "Select * from Categoria where Nombre=@Nombre";
                comando.Parameters.AddWithValue("@Nombre", nombre);
                var datos = comando.ExecuteReader();
                datos.Read();
                categoria = MapToCategoria(datos);
                categoria.Productos = ObtenerProductosCategoria(categoria.Nombre);
                return categoria;
            }
        }
        public List<Producto> ObtenerProductosCategoria(string nombre)
        {
            List<Producto> productos = new List<Producto>();
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "SELECT * FROM Producto WHERE NombreCategoria = @Nombre";
                comando.Parameters.AddWithValue("@Nombre", nombre);
                var datos = comando.ExecuteReader();
                if (datos.HasRows)
                {
                    while (datos.Read())
                    {
                        productos.Add(MapToProducto(datos));
                    }
                }
            }
            return productos;
        }
        public Producto MapToProducto(SqlDataReader datos)
        {
            if (!datos.HasRows) return null;
            Producto producto = new Producto();
            producto.Codigo = (string)datos["Codigo"];
            producto.Nombre = (string)datos["Nombre"];
            producto.Descripcion = (string)datos["Descripcion"];
            producto.Precio = (decimal)datos["Precio"];
            producto.Estado = (string)datos["Estado"];
            producto.NombreBodega = (string)datos["NombreBodega"];
            producto.NombreCategoria = (string)datos["NombreCategoria"];
            return producto;
        }
        public void Modificar(Categoria categoriaNueva)
        {
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "update Categoria set Detalle = @Detalle, Estado = @Estado WHERE Nombre = @Nombre";
                comando.Parameters.AddWithValue("@Nombre", categoriaNueva.Nombre);
                comando.Parameters.AddWithValue("@Detalle", categoriaNueva.Detalle);
                comando.Parameters.AddWithValue("@Estado", categoriaNueva.Estado);
                comando.ExecuteNonQuery();
            }
        }
        public void ModificarEstado(string nombre, string estado)
        {
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "update Categoria set Estado = @Estado where Nombre = @Nombre";
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Estado", estado);
                comando.ExecuteNonQuery();
            }
        }
        public void Eliminar(string nombre)
        {
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "delete Categoria where Nombre = @Nombre";
                comando.Parameters.AddWithValue("@Nombre", nombre);                
                comando.ExecuteNonQuery();
            }
        }
    }

}
