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
    public class CN_Sucursal
    {
        private CN_Conexion conexion = new CN_Conexion();

        //Agregar Sucursales
        public void AgregarSucursales(string Nombre, string Direccion, string Telefono)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_agregarSucursal", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Nombre", Nombre);
                    comando.Parameters.AddWithValue("@Direccion", Direccion);
                    comando.Parameters.AddWithValue("@Telefono", Telefono);
                    comando.ExecuteNonQuery();
                }
            }
        }

        //Mostrar sucursales
        public DataTable mostrarSucursal()
        {
            DataTable sucursales = new DataTable();
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_mostrarSucursal", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader leer = comando.ExecuteReader())
                    {
                        sucursales.Load(leer);
                    }
                }
            }
            return sucursales;
        }

        //editar sucursales
        public void EditarSucursal(int Id_sucursal, string Nombre, string Direccion, string Telefono)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_modificarSucursal", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id", Id_sucursal);
                    comando.Parameters.AddWithValue("@Nombre", Nombre);
                    comando.Parameters.AddWithValue("@Direccion", Direccion);
                    comando.Parameters.AddWithValue("@Telefono", Telefono);
                    comando.ExecuteNonQuery();
                }
            }
        }

        //eliminar sucursales
        public void EliminarSucursal(int Id_sucursal)
        {
            using (SqlConnection con = conexion.crearConexion())
            {
                con.Open();
                using (SqlCommand comando = new SqlCommand("P_eliminarSucursal", con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id", Id_sucursal);
                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
