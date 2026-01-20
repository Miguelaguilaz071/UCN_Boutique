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
    internal class CN_Marca
    {
        private CN_Conexion conexion = new CN_Conexion();

        //agregar Marca
        public void AgregarMarca(string Nombre)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_agregarMarca", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Nombre", Nombre);
                    comando.ExecuteNonQuery();
                }
            }
        }

        //mostrar Marcas
        public DataTable mostrarMarcas()
        {
            DataTable Marcas = new DataTable();
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_mostrarMarca", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader leer = comando.ExecuteReader())
                    {
                        Marcas.Load(leer);
                    }
                }
            }
            return Marcas;
        }

        //editar Marcas
        public void EditarMarca(int Id, string Nombre)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_modificarMarca", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id_marca", Id);
                    comando.Parameters.AddWithValue("@Nombre", Nombre);
                    comando.ExecuteNonQuery();
                }
            }
        }

        //eliminar roles
        public void EliminarMarca(int Id)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_eliminarMarca", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id_marca", Id);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
