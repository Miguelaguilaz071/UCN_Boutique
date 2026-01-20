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
    public class CN_Rol
    {
        private CN_Conexion conexion = new CN_Conexion();

        //agregar rol
        public void AgregarRol(string Nombre)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_agregarRol", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Nombre", Nombre);
                    comando.ExecuteNonQuery();
                }
            }
        }

        //mostrar Roles
        public DataTable mostrarRoles()
        {
            DataTable Roles = new DataTable();
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_mostrarRol", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader leer = comando.ExecuteReader())
                    {
                        Roles.Load(leer);
                    }
                }
            }
            return Roles;
        }

        //editar roles
        public void EditarRoles(int Id, string Nombre)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_modificarRol", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id", Id);
                    comando.Parameters.AddWithValue("@Nombre", Nombre);
                    comando.ExecuteNonQuery();
                }
            }
        }

        //eliminar roles
        public void EliminarRol(int Id)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_eliminarRol", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id", Id);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
