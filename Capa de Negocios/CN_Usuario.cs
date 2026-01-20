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
    public class CN_Usuario
    {
        private CN_Conexion conexion = new CN_Conexion();

        //logear usuario
        public DataTable LoginUsuario(string correo, string contrasena)
        {
            DataTable resultado = new DataTable();

            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_loginUsuario", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Correo", correo);
                    comando.Parameters.AddWithValue("@Contrasena", contrasena);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        resultado.Load(reader);
                    }
                }
            }

            return resultado;
        }

        //agregar Usuario
        public void agregarUsuario(int rol, string Nombre, string correo, string contraseña)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_agregarUsuario", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Rol", rol);
                    comando.Parameters.AddWithValue("@Nombre", Nombre);
                    comando.Parameters.AddWithValue("@Correo", correo);
                    comando.Parameters.AddWithValue("@Contrasena", contraseña);
                    comando.ExecuteNonQuery();
                }
            }
        }

        //mostrar usuarios
        public DataTable mostrarUsuario()
        {
            DataTable Usuarios = new DataTable();
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_mostrarUsuario", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader leer = comando.ExecuteReader())
                    {
                        Usuarios.Load(leer);
                    }
                }
            }
            return Usuarios;
        }

        //mostrar usuarios por rol
        public DataTable mostrarRolUsuario()
        {
            DataTable Usuarios = new DataTable();
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_mostrarRolUsuario", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader leer = comando.ExecuteReader())
                    {
                        Usuarios.Load(leer);
                    }
                }
            }
            return Usuarios;
        }

        //editar usuarios
        public void editarUsuario(int Id, int rol, string Nombre, string correo, string contrasena)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_modificarUsuario", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id_Usuario", Id);
                    comando.Parameters.AddWithValue("@Rol", rol);
                    comando.Parameters.AddWithValue("@Nombre", Nombre);
                    comando.Parameters.AddWithValue("@Correo", correo);
                    comando.Parameters.AddWithValue("@Contrasena", contrasena);
                    comando.ExecuteNonQuery();
                }
            }
        }

        //eliminar usuarios
        public void EliminarUsuario(int Id)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_eliminarUsuario", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id_usuario", Id);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
