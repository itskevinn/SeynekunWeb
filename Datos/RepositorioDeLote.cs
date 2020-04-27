using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entity;

namespace Datos {
    public class RepositorioDeLote {
        private readonly SqlConnection _conexión;
        private readonly List<Lote> _lotes = new List<Lote> ( );
        public RepositorioDeLote (GestionadorDeConexión conexión) {
            _conexión = conexión._conexion;
        }
        public void Guardar (Lote lote) {
            using (var comando = _conexión.CreateCommand ( )) {
                comando.CommandText = @"Insert Into lote (NumLot,Varr,NumArb,SisRen,FechSiem,Cult, EpCos, EpFlo,EstCos , EstTip)
values (@NumLot,@Varr,@NumArb,@SisRen,@FechSiem,@Cult,@EpCos,@EpFlo,@EstCos,@EstTip)";
                comando.Parameters.AddWithValue ("@NumLot", lote.NumeroLote);
                comando.Parameters.AddWithValue ("@Varr", lote.Variedad);
                comando.Parameters.AddWithValue ("@NumArb", lote.NumeroArbol);
                comando.Parameters.AddWithValue ("@SisRen", lote.SistemaRenovacion);
                comando.Parameters.AddWithValue ("@FechSiem", lote.FechaSiembra);
                comando.Parameters.AddWithValue ("@Cult", lote.Cultivo);
                comando.Parameters.AddWithValue ("@EpCos", lote.EpocaCosecha);
                comando.Parameters.AddWithValue ("@EpFlo", lote.EpocaFloriacion);
                comando.Parameters.AddWithValue ("@EstCos", lote.EstimadoCosecha);
                comando.Parameters.AddWithValue ("@EstTip", lote.TipoEstimado);
                var filas = comando.ExecuteNonQuery ( );
            }
        }        
        public List<Lote> ConsultarTodos ( ) {
            SqlDataReader lectorDeDatos;
            List<Lote> lotes = new List<Lote> ( );
            using (var comando = _conexión.CreateCommand ( )) {
                comando.CommandText = "Select * from lote ";
                lectorDeDatos = comando.ExecuteReader ( );
                if (lectorDeDatos.HasRows) {
                    while (lectorDeDatos.Read ( )) {
                        Lote lote = MapearDatosEnLector (lectorDeDatos);
                        lotes.Add (lote);
                    }
                }
            }
            return lotes;
        }

        private Lote MapearDatosEnLector (SqlDataReader lectorDeDatos) {
            if (!lectorDeDatos.HasRows) return null;
            Lote lote = new Lote ( );
            lote.NumeroLote = (int) lectorDeDatos["NumLot"];
            lote.Variedad = (string) lectorDeDatos["Varr"];
            lote.NumeroArbol = (int) lectorDeDatos["NumArb"];                     
            lote.SistemaRenovacion = (string) lectorDeDatos["SisRen"];                     
            lote.FechaSiembra = (int) lectorDeDatos["FechSiem"];                     
            lote.Cultivo = (string) lectorDeDatos["Cult"];                     
            lote.EpocaCosecha = (int) lectorDeDatos["EpCos"];                     
            lote.EpocaFloriacion = (int) lectorDeDatos["EpFlo"];                     
            lote.EstimadoCosecha = (int) lectorDeDatos["EstCos"];                     
            lote.TipoEstimado = (string) lectorDeDatos["EstTip"];                     
            return lote;
        }
    }
}