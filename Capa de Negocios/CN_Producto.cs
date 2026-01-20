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
    internal class CN_Producto
    {
        private CN_Conexion conexion = new CN_Conexion();

        //agregar Producto
        public void agregarProducto(int categoria, int Marca, string Nombre, string Descripcion, double precio, byte[] imagen)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_agregarProducto", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Categoria", categoria);
                    comando.Parameters.AddWithValue("@Marca", Marca);
                    comando.Parameters.AddWithValue("@Nombre", Nombre);
                    comando.Parameters.AddWithValue("@Descripcion", Descripcion);
                    comando.Parameters.AddWithValue("@precio", precio);
                    comando.Parameters.AddWithValue("@imagen", imagen);
                    comando.ExecuteNonQuery();
                }
            }
        }

        //mostrar productos
        public DataTable mostrarProductos()
        {
            DataTable productos = new DataTable();
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_mostrarProducto", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader leer = comando.ExecuteReader())
                    {
                        productos.Load(leer);
                    }
                }
            }
            return productos;
        }

        //mostrar productos por categoria
        public DataTable categoriaProductos()
        {
            DataTable productos = new DataTable();
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_categoriaProducto", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader leer = comando.ExecuteReader())
                    {
                        productos.Load(leer);
                    }
                }
            }
            return productos;
        }

        //Mostrar productos por marca
        public DataTable marcaProductos()
        {
            DataTable productos = new DataTable();
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_marcaProducto", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader leer = comando.ExecuteReader())
                    {
                        productos.Load(leer);
                    }
                }
            }
            return productos;
        }

        //editar Producto
        public void editarProducto(int Id, int categoria, int Marca, string Nombre, string Descripcion, double precio, byte[] imagen)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_editarProducto", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id_producto", Id);
                    comando.Parameters.AddWithValue("@Categoria", categoria);
                    comando.Parameters.AddWithValue("@Marca", Marca);
                    comando.Parameters.AddWithValue("@Nombre", Nombre);
                    comando.Parameters.AddWithValue("@Descripcion", Descripcion);
                    comando.Parameters.AddWithValue("@precio", precio);
                    comando.Parameters.AddWithValue("@imagen", imagen);
                    comando.ExecuteNonQuery();
                }
            }
        }

        //eliminar productos
        public void EliminarProducto(int Id)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_eliminarProducto", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id_producto", Id);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
