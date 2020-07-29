using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class DaoProgreso
    {
        SqlConnection conexion;
        public DaoProgreso()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
    }
}
