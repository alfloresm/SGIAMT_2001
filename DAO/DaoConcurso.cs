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
        public DataTable ListarConcursos()
        {
            DataTable dtconcurso = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Listar_Concursos]", conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtconcurso = new DataTable();
            daAdaptador.Fill(dtconcurso);
            conexion.Close();
            return dtconcurso;
        }

    }
}
