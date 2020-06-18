using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
    public class DaoConcurso
    {
        SqlConnection conexion;
        public DaoConcurso()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
    }
}
