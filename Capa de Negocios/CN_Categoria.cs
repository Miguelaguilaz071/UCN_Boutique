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
    public class CN_Categoria
    {
        private CN_Conexion conexion = new CN_Conexion();

        //agregar Categoria
        public void AgregarCategoria(string Nombre)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_agregarCategoria", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Nombre", Nombre);
                    comando.ExecuteNonQuery();
                }
            }
        }

        //mostrar categorias
        public DataTable mostrarCategorias()
        {
            DataTable Categorias = new DataTable();
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_mostrarCategoria", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader leer = comando.ExecuteReader())
                    {
                        Categorias.Load(leer);
                    }
                }
            }
            return Categorias;
        }

        //editar categorias
        public void EditarCategorias(int Id, string Nombre)
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

        //eliminar Categoria
        public void EliminarCategoria(int Id)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_eliminarCategoria", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id", Id);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
