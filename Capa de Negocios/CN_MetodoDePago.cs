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
    internal class CN_MetodoDePago
    {
        private CN_Conexion conexion = new CN_Conexion();

        //agregar metodo de pago
        public void AgregarMetodoPago(int Id_usuario, int Id_tipoTarjeta, string Token, string FechaExp)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_agregarMetodoPago", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id_usuario", Id_usuario);
                    comando.Parameters.AddWithValue("@Id_tipoTarjeta", Id_tipoTarjeta);
                    comando.Parameters.AddWithValue("@Token", Token);
                    comando.Parameters.AddWithValue("@FechaExp", FechaExp);
                    comando.ExecuteNonQuery();
                }
            }
        }

        //mostrar metodos de pago
        public DataTable mostrarMetodosPago()
        {
            DataTable Metodo = new DataTable();
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_mostrarMetodoPago", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader leer = comando.ExecuteReader())
                    {
                        Metodo.Load(leer);
                    }
                }
            }
            return Metodo;
        }

        //editar metodos de pago
        public void EditarMetodoPago(int Id_metodoPago,int Id_usuario, int Id_tipoTarjeta, string Token, string FechaExp)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_modificarMetodoPago", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id_metodoPago", Id_metodoPago);
                    comando.Parameters.AddWithValue("@Id_usuario", Id_usuario);
                    comando.Parameters.AddWithValue("@Id_tipoTarjeta", Id_tipoTarjeta);
                    comando.Parameters.AddWithValue("@Token", Token);
                    comando.Parameters.AddWithValue("@FechaExp", FechaExp);
                    comando.ExecuteNonQuery();
                }
            }
        }

        //eliminar metodo de pago
        public void EliminarMetodoPago(int Id_metodoPago)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_eliminarMetodoPago", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id_metodoPago", Id_metodoPago);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
