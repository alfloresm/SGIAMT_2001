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
    public class DaoAsistencia
    {
        SqlConnection conexion;
        public DaoAsistencia()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void ObtenerAlumnoAsis(DtoUsuario objUsuario)
        {
            SqlCommand command = new SqlCommand("SP_Obtener_Alumno", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", objUsuario.PK_IU_DNI);
            DataSet ds = new DataSet();
            conexion.Open();
            SqlDataAdapter sqladap = new SqlDataAdapter(command);
            sqladap.Fill(ds);
            sqladap.Dispose();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                objUsuario.PK_IU_DNI = reader[0].ToString();
                objUsuario.VU_Nombre = reader[1].ToString();
                objUsuario.VU_APaterno = reader[2].ToString();
                objUsuario.VU_AMaterno = reader[3].ToString();
                objUsuario.FK_ITN_TipoNivel = int.Parse(reader[4].ToString());
                objUsuario.FK_IN_CodNivel = int.Parse(reader[5].ToString());
                objUsuario.VU_Horario = reader[6].ToString();
            }
            conexion.Close();
            conexion.Dispose();
        }

        public void RegistrarAsistencia(DtoAsistencia objdtoAsis)
        {
            try
            {
                SqlCommand command = new SqlCommand("SP_RegistrarAsistencia", conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@estado", objdtoAsis.VA_EstadoAsistencia);
                command.Parameters.AddWithValue("@fecha", objdtoAsis.fecha);
                command.Parameters.AddWithValue("@dni", objdtoAsis.FK_VU_Dni);

                conexion.Open();
                command.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            {

                throw;

            }
        }
        public DataSet desplegarTipoNivel()
        {
            SqlDataAdapter listanivel = new SqlDataAdapter("SP_DesplegableTipoNivel", conexion);
            listanivel.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet DS = new DataSet();
            listanivel.Fill(DS);
            return DS;
        }
        public DataSet desplegarNivel()
        {
            SqlDataAdapter listanivel = new SqlDataAdapter("SP_DesplegableNivel2", conexion);
            listanivel.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet DS = new DataSet();
            listanivel.Fill(DS);
            return DS;
        }
    }
}
