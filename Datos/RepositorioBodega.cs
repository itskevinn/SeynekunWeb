using Entity;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace Datos
{
    public class RepositorioBodega
    {
        private readonly SqlConnection _conexión;

        public RepositorioBodega(GestionadorDeConexión conexión)
        {
            _conexión = conexión._conexion;
        }
        public void Eliminar(string nombre)
        {
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "DELETE FROM Bodegas WHERE Nombre=@Nombre";
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.ExecuteNonQuery();
            }
        }
        public void Guardar(Bodega bodega)
        {
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = @"Insert Into Bodegas (Nombre, Detalle, Estado, Direccion) values (@Nombre,@Detalle, @Estado, @Direccion)";
                comando.Parameters.AddWithValue("@Nombre", bodega.Nombre);
                comando.Parameters.AddWithValue("@Detalle", bodega.Detalle);                
                comando.Parameters.AddWithValue("@Estado", bodega.Estado);
                comando.Parameters.AddWithValue("@Direccion", bodega.Direccion);
                var filas = comando.ExecuteNonQuery();
            }
        }

        public List<Bodega> Consultar()
        {
            List<Bodega> bodegas = new List<Bodega>();
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "Select * from Bodegas";
                var datos = comando.ExecuteReader();
                if (datos.HasRows)
                {
                    while (datos.Read())
                    {
                        bodegas.Add(MapToBodega(datos));
                    }
                }
            }
            return bodegas;
        }

        private Bodega MapToBodega(SqlDataReader datos)
        {
            if (!datos.HasRows) return null;
            Bodega bodega = new Bodega();
            bodega.Nombre = (string)datos["Nombre"];            
            bodega.Detalle = (string)datos["Detalle"];
            bodega.Estado = (string)datos["Estado"];
            bodega.Direccion = (string)datos["Direccion"];
            bodega.Productos = new List<Producto>();
            return bodega;
        }
        public Bodega BuscarxId(string nombre)
        {
            Bodega bodega = new Bodega();
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "Select * from Bodegas where Nombre=@Nombre";
                comando.Parameters.AddWithValue("@Nombre", nombre);
                var datos = comando.ExecuteReader();
                datos.Read();
                bodega = MapToBodega(datos);
                bodega.Productos = ObtenerProductosBodega(bodega.Nombre);
                return bodega;
            }
        }
        public List<Producto> ObtenerProductosBodega(string nombre)
        {
            List<Producto> productos = new List<Producto>();
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "SELECT * FROM Producto WHERE NombreBodega = @Nombre";
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
        public void Modificar(Bodega bodegaNueva)
        {
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "update Bodegas set  Detalle = @Detalle, Direccion = @Direccion WHERE Nombre = @Nombre";
                comando.Parameters.AddWithValue("@Nombre", bodegaNueva.Nombre);
                comando.Parameters.AddWithValue("@Detalle", bodegaNueva.Detalle);
                comando.Parameters.AddWithValue("@Direccion", bodegaNueva.Direccion);
                comando.ExecuteNonQuery();
            }
        }
        public void ModificarEstado(string nombre, string estado)
        {
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "update Bodegas set Estado = @Estado where Nombre = @Nombre";
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Estado", estado);
                comando.ExecuteNonQuery();
            }
        }
    }
}