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

        public void Guardar(Bodega bodega)
        {
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = @"Insert Into Bodegas (Nombre, Detalle, Valor, Estado) values (@Nombre,@Detalle,@Valor, @Estado)";
                comando.Parameters.AddWithValue("@Nombre", bodega.Nombre);
                comando.Parameters.AddWithValue("@Detalle", bodega.Detalle);
                comando.Parameters.AddWithValue("@Valor", bodega.Valor);
                comando.Parameters.AddWithValue("@Estado", bodega.Estado);
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
            bodega.Valor = (decimal)datos["Valor"];
            bodega.Detalle = (string)datos["Detalle"];
            bodega.Estado = (string)datos["Estado"];
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
            producto.Precio = (decimal)datos["Precio"]
            producto.Estado = (string)datos["Estado"];
            producto.NombreBodega = (string)datos["NombreBodega"];
            producto.NombreCategoria = (string)datos["NombreCategoria"];
            return producto;
        }
        public void Modificar(Bodega bodegaNueva)
        {
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "update Bodegas set Nombre = @Nombre, Detalle = @Detalle, Valor = @Valor";
                comando.Parameters.AddWithValue("@Nombre", bodegaNueva.Nombre);
                comando.Parameters.AddWithValue("@Detalle", bodegaNueva.Detalle);
                comando.Parameters.AddWithValue("@Valor", bodegaNueva.Valor);
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