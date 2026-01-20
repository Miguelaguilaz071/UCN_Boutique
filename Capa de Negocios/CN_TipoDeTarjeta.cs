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
    internal class CN_TipoDeTarjeta
    {
        private CN_Conexion conexion = new CN_Conexion();

        //agregar rol
        public void AgregarTipoTarjeta(string Nombre)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_agregarTipoTarjeta", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Nombre", Nombre);
                    comando.ExecuteNonQuery();
                }
            }
        }

        //mostrar Tipos de tarjetas
        public DataTable mostrarTiposTarjetas()
        {
            DataTable Tipos = new DataTable();
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_mostrarTipoTarjeta", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader leer = comando.ExecuteReader())
                    {
                        Tipos.Load(leer);
                    }
                }
            }
            return Tipos;
        }

        //editar tipos de tarjetas
        public void EditarTipoTarjeta(int Id, string Nombre)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_modificarTipoTarjeta", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id_TipoTarjeta", Id);
                    comando.Parameters.AddWithValue("@Nombre", Nombre);
                    comando.ExecuteNonQuery();
                }
            }
        }

        //eliminar roles
        public void EliminarTipoTarjeta(int Id)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_eliminarTipoTarjeta", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id_TipoTarjeta", Id);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
