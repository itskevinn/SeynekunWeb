using Entity;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
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
            bodega.Ajustes = new List<AjusteInventario>();        
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
                bodega.Ajustes = ObtenerAjusteInventariosBodega(nombre);
                return bodega;
            }
        }
        public List<AjusteInventario> ObtenerAjusteInventariosBodega(string nombre)
        {
            List<AjusteInventario> ajusteInventarios = new List<AjusteInventario>();
            using (var comando = _conexión.CreateCommand())
            {
                comando.CommandText = "SELECT * FROM AjusteInventarios WHERE NombreBodega = @Nombre";
                comando.Parameters.AddWithValue("@Nombre", nombre);
                var datos = comando.ExecuteReader();
                if (datos.HasRows)
                {
                    while (datos.Read())
                    {
                        ajusteInventarios.Add(MapToAjusteInventario(datos));
                    }
                }
            }
            return ajusteInventarios;
        }
       public AjusteInventario MapToAjusteInventario(SqlDataReader datos)
        {
            if (!datos.HasRows) return null;
            AjusteInventario ajusteInventario = new AjusteInventario();
            ajusteInventario.Fecha = (DateTime)datos["Fecha"];
            ajusteInventario.Codigo = (decimal)datos["Codigo"];
            ajusteInventario.Descipcion = (string)datos["Descipcion"];
            ajusteInventario.Cantidad = (decimal)datos["Cantidad"];
            ajusteInventario.CodigoElemento = (string)datos["CodigoElemento"];           
            ajusteInventario.Tipo = (string)datos["Tipo"];
            ajusteInventario.NombreBodega = (string)datos["NombreBodega"];
            return ajusteInventario;
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