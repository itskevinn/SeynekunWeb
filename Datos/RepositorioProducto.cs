using System.Collections.Generic;
using System.Data.SqlClient;
using Entity;

namespace Datos
{
    public class RepositorioProducto
    {
        private readonly SqlConnection _conexión;

        public RepositorioProducto(GestionadorDeConexión conexión)
        {
            _conexión = conexión._conexion;
        }

        public void Guardar(Producto producto)
        {
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = @"Insert Into Producto (Codigo,Nombre,Descripcion,Precio,NombreCategoria,Estado,NombreBodega)
                    values (@Codigo,@Nombre,@Descripcion,@Precio,@NombreCategoria,@Estado,@NombreBodega)";
                comando.Parameters.AddWithValue("@Codigo", producto.Codigo);
                comando.Parameters.AddWithValue("@Nombre", producto.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                comando.Parameters.AddWithValue("@Precio", producto.Precio);
                comando.Parameters.AddWithValue("@NombreCategoria", producto.NombreCategoria);
                comando.Parameters.AddWithValue("@Estado", producto.Estado);
                comando.Parameters.AddWithValue("@NombreBodega", producto.NombreBodega);
                var filas = comando.ExecuteNonQuery();
            }
        }

        public List<Producto> Consultar()
        {
            List<Producto> productos = new List<Producto>();
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "Select * from Producto";
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

        private Producto MapToProducto(SqlDataReader datos)
        {
            if (!datos.HasRows) return null;
            Producto producto = new Producto();
            producto.Codigo = (string)datos["Codigo"];
            producto.Nombre = (string)datos["Nombre"];
            producto.Descripcion = (string)datos["Descripcion"];
            producto.Precio = (decimal)datos["Precio"];
            producto.NombreCategoria = (string)datos["NombreCategoria"];
            producto.Estado = (string)datos["Estado"];
            producto.NombreBodega = (string)datos["NombreBodega"];
            return producto;
        }
        public Producto BuscarxId(string Codigo)
        {
            Producto producto = new Producto();
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "Select * from Producto where Codigo=@Codigo";
                comando.Parameters.AddWithValue("@Codigo", Codigo);
                var datos = comando.ExecuteReader();
                datos.Read();
                return MapToProducto(datos);
            }
        }

        public void Modificar(Producto productoNuevo)
        {
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "update Producto set Nombre = @Nombre, Descripcion = @Descripcion, Estado = @Estado,  Precio = @Precio, NombreCategoria = @NombreCategoria, NombreBodega = @NombreBodega where Codigo = @Codigo";
                comando.Parameters.AddWithValue("@Codigo", productoNuevo.Codigo);
                comando.Parameters.AddWithValue("@Nombre", productoNuevo.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", productoNuevo.Descripcion);
                comando.Parameters.AddWithValue("@Estado", productoNuevo.Estado);
                comando.Parameters.AddWithValue("@Precio", productoNuevo.Precio);
                comando.Parameters.AddWithValue("@NombreCategoria", productoNuevo.NombreCategoria);
                comando.Parameters.AddWithValue("@NombreBodega", productoNuevo.NombreBodega);
                comando.ExecuteNonQuery();
            }
        }
        public void ModificarEstado(string Codigo, string estado)
        {
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "update Producto set Estado = @Estado where Codigo = @Codigo";
                comando.Parameters.AddWithValue("@Codigo", Codigo);
                comando.Parameters.AddWithValue("@Estado", estado);
                comando.ExecuteNonQuery();
            }
        }

    }
}