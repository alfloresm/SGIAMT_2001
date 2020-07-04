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
            SqlCommand command = new SqlCommand("SP_Listar_Concursos", conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtconcurso = new DataTable();
            daAdaptador.Fill(dtconcurso);
            conexion.Close();
            return dtconcurso;
        }
        public void RegistrarConcurso(DtoConcurso objConcurso)
        {
            
            SqlCommand command = new SqlCommand("SP_Registrar_Concurso", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@nombre", objConcurso.VC_NombreCon);
            command.Parameters.AddWithValue("@direccion", objConcurso.VC_LugarCon);
            command.Parameters.AddWithValue("@fechac", objConcurso.DTC_FechaConcurso);
            command.Parameters.AddWithValue("@cantS", objConcurso.IC_CantidadSeriado);
            command.Parameters.AddWithValue("@cantN", objConcurso.IC_CantidadNovel);

            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void ActualizarConcurso(DtoConcurso objConcurso)
        {

            SqlCommand command = new SqlCommand("SP_Actualizar_Concurso", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", objConcurso.PK_IC_IdConcurso);
            command.Parameters.AddWithValue("@nombre", objConcurso.VC_NombreCon);
            command.Parameters.AddWithValue("@direccion", objConcurso.VC_LugarCon);
            command.Parameters.AddWithValue("@fechac", objConcurso.DTC_FechaConcurso);
            command.Parameters.AddWithValue("@cantS", objConcurso.IC_CantidadSeriado);
            command.Parameters.AddWithValue("@cantN", objConcurso.IC_CantidadNovel);
            command.Parameters.AddWithValue("@est", objConcurso.FK_IEC_IdEstado);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void ObtenerConcurso(DtoConcurso objConcurso)
        {
            SqlCommand command = new SqlCommand("SP_Obtener_Concurso", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", objConcurso.PK_IC_IdConcurso);
            DataSet ds = new DataSet();
            conexion.Open();
            SqlDataAdapter moldura = new SqlDataAdapter(command);
            moldura.Fill(ds);
            moldura.Dispose();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                objConcurso.PK_IC_IdConcurso = int.Parse(reader[0].ToString());
                objConcurso.VC_NombreCon = reader[1].ToString();
                objConcurso.VC_LugarCon = reader[2].ToString();
                objConcurso.DTC_FechaConcurso = Convert.ToDateTime(reader[3].ToString());
                objConcurso.IC_CantidadSeriado = int.Parse(reader[4].ToString());
                objConcurso.IC_CantidadNovel = int.Parse(reader[5].ToString());
                objConcurso.FK_IEC_IdEstado = int.Parse(reader[6].ToString());
            }
            conexion.Close();
            conexion.Dispose();
        }

    }
}
