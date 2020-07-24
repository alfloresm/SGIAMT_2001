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
    public class DaoAlumno
    {
        SqlConnection conexion;
        public DaoAlumno()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }

        public void RegistrarAlumno(DtoUsuario objAlumno)
        {

            SqlCommand command = new SqlCommand("SP_RegistrarAlumno", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@dni", objAlumno.PK_IU_DNI);
            command.Parameters.AddWithValue("@nombre", objAlumno.VU_Nombre);
            command.Parameters.AddWithValue("@apellidoP", objAlumno.VU_APaterno);
            command.Parameters.AddWithValue("@apellidoM", objAlumno.VU_AMaterno);
            command.Parameters.AddWithValue("@fechaNacimiento", objAlumno.DTU_FechaNacimiento);
            command.Parameters.AddWithValue("@contrasenia", objAlumno.VU_Contrasenia);
            command.Parameters.AddWithValue("@sexo", objAlumno.VU_Sexo);
            command.Parameters.AddWithValue("@nombreAcademia", objAlumno.VU_NAcademia);
            command.Parameters.AddWithValue("@correo", objAlumno.VU_Correo);
            command.Parameters.AddWithValue("@celular", objAlumno.VU_Celular);
            command.Parameters.AddWithValue("@estado", objAlumno.VU_Estado);
            command.Parameters.AddWithValue("@horario", objAlumno.VU_Horario);
            command.Parameters.AddWithValue("@direccion", objAlumno.VU_Direccion);
            command.Parameters.AddWithValue("@cat", objAlumno.FK_ICA_CodCat);
            command.Parameters.AddWithValue("@nivel", objAlumno.FK_IN_CodNivel);
            command.Parameters.AddWithValue("@tipo_nivel", objAlumno.FK_ITN_TipoNivel);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }

        public DataTable ListarAlumnos()
        {
            DataTable dtAlumno = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Listar_Alumno", conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtAlumno = new DataTable();
            daAdaptador.Fill(dtAlumno);
            conexion.Close();
            return dtAlumno;
        }

        //tabla de alumnos para administrar asistencia
        public DataTable ListarAlumnosA()
        {
            DataTable dtAlumnos = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Listar_Alumnos2", conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtAlumnos = new DataTable();
            daAdaptador.Fill(dtAlumnos);
            conexion.Close();
            return dtAlumnos;
        }
        public int ObtenerCategoria(int anio)
        {
            try
            {
                int valor_retornado = 0;
                SqlCommand cmd = new SqlCommand("select PK_ICA_CodCat from T_Categoria where " + anio + " >= ICA_AnioInicio and " + anio + " <= ICA_Aniofin", conexion);
                Console.WriteLine(cmd);
                conexion.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    valor_retornado = int.Parse(reader[0].ToString());
                }
                conexion.Close();
                return valor_retornado;
            }
            catch (Exception)
            {

                throw;

            }
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
