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
    public class CN_InventarioSucursal
    {
        private CN_Conexion conexion = new CN_Conexion();

        //agregar stock
        public void AgregarStock(int Id_sucursal, int Id_producto, int stock)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_agregarStock", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id_sucursal", Id_sucursal);
                    comando.Parameters.AddWithValue("@Id_producto", Id_producto);
                    comando.Parameters.AddWithValue("@StockActual", stock);
                    comando.ExecuteNonQuery();
                }
            }
        }

        //mostrar stock actual
        public DataTable mostrarStock()
        {
            DataTable Stock = new DataTable();
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_mostrarStock", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader leer = comando.ExecuteReader())
                    {
                        Stock.Load(leer);
                    }
                }
            }
            return Stock;
        }

        //editar roles
        public void EditarStock(int Id_sucursal, int Id_producto, int stock)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_modificarStock", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id_sucursal", Id_sucursal);
                    comando.Parameters.AddWithValue("@Id_producto", Id_producto);
                    comando.Parameters.AddWithValue("@StockActual", stock);
                    comando.ExecuteNonQuery();
                }
            }
        }

        //eliminar Stock (manualmente)
        public void EliminarStock(int Id_sucursal, int Id_producto)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_eliminarStock", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id_sucursal", Id_sucursal);
                    comando.Parameters.AddWithValue("@Id_producto", Id_producto);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
