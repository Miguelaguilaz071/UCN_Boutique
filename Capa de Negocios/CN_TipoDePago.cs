using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_de_Negocios;

namespace Capa_de_Negocios
{
    public class CN_TipoPago
    {
        private CN_Conexion conexion = new CN_Conexion();

        // Agregar tipo de pago
        public void AgregarTipoPago(string nombre)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_agregarTipoPago", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Nombre", nombre);
                    comando.ExecuteNonQuery();
                }
            }
        }

        // Mostrar tipos de pago
        public DataTable MostrarTiposPago()
        {
            DataTable tiposPago = new DataTable();
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_mostrarTipoPago", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader leer = comando.ExecuteReader())
                    {
                        tiposPago.Load(leer);
                    }
                }
            }
            return tiposPago;
        }

        // Modificar tipo de pago
        public void EditarTipoPago(int idTipoPago, string nombre)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_modificarTipoPago", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id_tipoPago", idTipoPago);
                    comando.Parameters.AddWithValue("@Nombre", nombre);
                    comando.ExecuteNonQuery();
                }
            }
        }

        // Eliminar tipo de pago
        public void EliminarTipoPago(int idTipoPago)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_eliminarTipoPago", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id_tipoPago", idTipoPago);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}