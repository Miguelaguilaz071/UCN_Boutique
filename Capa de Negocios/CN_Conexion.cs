using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Capa_de_Negocios
{
    internal class CN_Conexion
    {
        private readonly string cadenaConexion = @"Server=pc\SQLEXPRESS;Database=UCN_Boutique_2_0;Integrated Security=true;";

        public SqlConnection crearConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
