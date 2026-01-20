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
    internal class CN_DetalleCompra
    {
        private CN_Conexion conexion = new CN_Conexion();

        //agregar detalles de compra
        public void AgregarDetalleCompra(int Id_compra, int Id_producto, int Id_sucursal, int Cantidad, double precioUnitario)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_agregarDetalleCompra", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id_compra", Id_compra);
                    comando.Parameters.AddWithValue("@Id_producto", Id_producto);
                    comando.Parameters.AddWithValue("@Id_sucursal", Id_sucursal);
                    comando.Parameters.AddWithValue("@Cantidad", Cantidad);
                    comando.Parameters.AddWithValue("@precioUnitario", precioUnitario);
                    comando.ExecuteNonQuery();
                }
            }
        }

        //mostrar detalles de compras
        public DataTable mostrarDetalleCompra()
        {
            DataTable Detalles = new DataTable();
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_mostrarDetalleCompra", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader leer = comando.ExecuteReader())
                    {
                        Detalles.Load(leer);
                    }
                }
            }
            return Detalles;
        }

        //mostrar detalles por compra
        public DataTable mostrarDetallesporCompra()
        {
            DataTable Detalles = new DataTable();
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_mostrarDetallesPorCompra", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader leer = comando.ExecuteReader())
                    {
                        Detalles.Load(leer);
                    }
                }
            }
            return Detalles;
        }

        //editar detalles de compra
        public void EditarDetalleCompra(int Id_compra, int Id_producto, int Id_sucursal, int Cantidad, double precioUnitario)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_modificarDetalleCompra", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id_compra", Id_compra);
                    comando.Parameters.AddWithValue("@Id_producto", Id_producto);
                    comando.Parameters.AddWithValue("@Id_sucursal", Id_sucursal);
                    comando.Parameters.AddWithValue("@Cantidad", Cantidad);
                    comando.Parameters.AddWithValue("@precioUnitario", precioUnitario);
                    comando.ExecuteNonQuery();
                }
            }
        }

        //eliminar roles
        public void EliminarDetalleCompra(int Id_compra, int Id_producto, int Id_sucursal)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_eliminarDetalleCompra", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id_compra", Id_compra);
                    comando.Parameters.AddWithValue("@Id_producto", Id_producto);
                    comando.Parameters.AddWithValue("@Id_sucursal", Id_sucursal);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
