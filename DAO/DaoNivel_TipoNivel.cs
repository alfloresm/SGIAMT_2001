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
    public class DaoNivel_TipoNivel
    {
        SqlConnection conexion;
        public DaoNivel_TipoNivel()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public DataSet desplegarNivel_TipoNivel()
        {
            SqlDataAdapter listanivel = new SqlDataAdapter("SP_DesplegableClases", conexion);
            listanivel.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet DS = new DataSet();
            listanivel.Fill(DS);
            return DS;
        }
    }
}
