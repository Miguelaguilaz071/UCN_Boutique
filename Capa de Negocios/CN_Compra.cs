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
    internal class CN_Compra
    {
        private CN_Conexion conexion = new CN_Conexion();

        //agregar Compra
        public void AgregarCompra(int Usuario, int Sucursal, int MetodoPago)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_agregarCompra", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Usuario", Usuario);
                    comando.Parameters.AddWithValue("@Sucursal", Sucursal);
                    comando.Parameters.AddWithValue("@MetodoPago", MetodoPago);
                    comando.ExecuteNonQuery();
                }
            }
        }

        //mostrar compra
        public DataTable MostrarCompra()
        {
            DataTable Compras = new DataTable();
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_mostrarCompra", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader leer = comando.ExecuteReader())
                    {
                        Compras.Load(leer);
                    }
                }
            }
            return Compras;
        }

        //mostrar compras de un usuario
        public DataTable MostrarUsuarioCompra()
        {
            DataTable Compras = new DataTable();
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_usuarioCompra", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader leer = comando.ExecuteReader())
                    {
                        Compras.Load(leer);
                    }
                }
            }
            return Compras;
        }

        //editar compras
        public void EditarCompra(int Id_compra, int Usuario, int Sucursal, int MetodoPago)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_modificarCompra", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id_compra", Id_compra);
                    comando.Parameters.AddWithValue("@Usuario", Usuario);
                    comando.Parameters.AddWithValue("@Sucursal", Sucursal);
                    comando.Parameters.AddWithValue("@MetodoPago", MetodoPago);
                    comando.ExecuteNonQuery();
                }
            }
        }

        //eliminar compras
        public void EliminarCompra(int Id_compra)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_eliminarCompra", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id_compra", Id_compra);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
