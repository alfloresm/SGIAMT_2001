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

        public void ActualizarAlumno(DtoUsuario objAlumno)
        {
            try
            {
                SqlCommand command = new SqlCommand("SP_Actualizar_Alumno", conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@dni", objAlumno.PK_IU_DNI);
                command.Parameters.AddWithValue("@nombre", objAlumno.VU_Nombre);
                command.Parameters.AddWithValue("@apellidoP", objAlumno.VU_APaterno);
                command.Parameters.AddWithValue("@apellidoM", objAlumno.VU_AMaterno);
                command.Parameters.AddWithValue("@fechaNacimiento", objAlumno.DTU_FechaNacimiento);
                command.Parameters.AddWithValue("@sexo", objAlumno.VU_Sexo);
                command.Parameters.AddWithValue("@correo", objAlumno.VU_Correo);
                command.Parameters.AddWithValue("@celular", objAlumno.VU_Celular);
                command.Parameters.AddWithValue("@horario", objAlumno.VU_Horario);
                command.Parameters.AddWithValue("@direccion", objAlumno.VU_Direccion);
                command.Parameters.AddWithValue("@cat", objAlumno.FK_ICA_CodCat);
                command.Parameters.AddWithValue("@nivel", objAlumno.FK_IN_CodNivel);
                command.Parameters.AddWithValue("@tipo_nivel", objAlumno.FK_ITN_TipoNivel);
                conexion.Open();
                command.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public void ObtenerAlumno2(DtoUsuario objAlumno)
        {
            try
            {
                SqlCommand command = new SqlCommand("SP_Obtener_Alumno_Actualizar", conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", objAlumno.PK_IU_DNI);
                DataSet ds = new DataSet();
                conexion.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(command);
                adapt.Fill(ds);
                adapt.Dispose();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    //cambiar estos campos
                    objAlumno.PK_IU_DNI = reader[0].ToString();
                    objAlumno.VU_Nombre = reader[1].ToString();
                    objAlumno.VU_APaterno = reader[2].ToString();
                    objAlumno.VU_AMaterno = reader[3].ToString();
                    objAlumno.DTU_FechaNacimiento = Convert.ToDateTime(reader[4].ToString());
                    objAlumno.VU_Sexo = reader[5].ToString();
                    objAlumno.VU_Direccion = reader[6].ToString();
                    objAlumno.VU_Correo = reader[7].ToString();
                    objAlumno.VU_Celular = reader[8].ToString();
                    objAlumno.FK_IN_CodNivel = int.Parse(reader[9].ToString());
                    objAlumno.VU_Horario = reader[10].ToString();
                }
                conexion.Close();
                conexion.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        //tabla de alumnos para administrar asistencia
        public DataTable ListarAlumnosA()
        {
            //@"data source=ALE\SQLEXPRESS; initial catalog=BD_SGIAMT; integrated security=SSPI;";

            SqlConnection con = new SqlConnection(@"data source=ALE\SQLEXPRESS; initial catalog=BD_SGIAMT; integrated security=SSPI;");
            DataTable dtAlumnos = null;
            con.Open();
            SqlCommand command = new SqlCommand("SP_Listar_Alumnos2", con);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtAlumnos = new DataTable();
            daAdaptador.Fill(dtAlumnos);
            con.Close();
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
        public DataTable ListarAlumnosTodosA()
        {
            //@"data source=ALE\SQLEXPRESS; initial catalog=BD_SGIAMT; integrated security=SSPI;";

            SqlConnection con = new SqlConnection(@"data source=LAPTOP-VLJRLSBM\SQLEXPRESS; initial catalog=BD_SGIAMT; integrated security=SSPI;");
            DataTable dtAsistencia = null;
            con.Open();
            SqlCommand command = new SqlCommand("SP_Listar_Alumnos_Total", con);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtAsistencia = new DataTable();
            daAdaptador.Fill(dtAsistencia);
            con.Close();
            return dtAsistencia;
        }
    }
}
