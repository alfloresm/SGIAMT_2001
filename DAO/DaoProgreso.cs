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
    public class DaoProgreso
    {
        SqlConnection conexion;
        public DaoProgreso()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public void RegistrarProgreso(DtoProgreso objdtopProg)
        {
            SqlCommand command = new SqlCommand("SP_RegistrarProgreso", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@nombreP", objdtopProg.VP_NombreProgreso);
            command.Parameters.AddWithValue("@notaPasos", objdtopProg.DP_NotaPasos);
            command.Parameters.AddWithValue("@notaTecnica", objdtopProg.DP_NotaTecnica);
            command.Parameters.AddWithValue("@notaInteres", objdtopProg.DP_NotaInteres);
            command.Parameters.AddWithValue("@notaHabilidad", objdtopProg.DP_NotaHabilidad);
            command.Parameters.AddWithValue("@totalNota", objdtopProg.DP_TotalNota);
            command.Parameters.AddWithValue("@observacion", objdtopProg.VP_Observacion);
            command.Parameters.AddWithValue("@codasi", objdtopProg.FK_IA_CodAsi);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }

        public DataTable ListarProgresosA()
        {
            SqlConnection con = new SqlConnection(@"data source=ALE\SQLEXPRESS; initial catalog=BD_SGIAMT; integrated security=SSPI;");
            DataTable dtAsistencia = null;
            con.Open();
            SqlCommand command = new SqlCommand("SP_Listar_Alumnos_Progreso", con);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtAsistencia = new DataTable();
            daAdaptador.Fill(dtAsistencia);
            con.Close();
            return dtAsistencia;
        }
    }
}
