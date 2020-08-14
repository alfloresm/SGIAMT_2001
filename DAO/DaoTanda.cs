using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;


namespace DAO
{
    public class DaoTanda
    {
        SqlConnection conexion;

        public DaoTanda()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public bool SelectTanda(DtoTanda objTan)//encuentra tanda
        {
            string Select = "SELECT * from T_Tanda where PK_IT_CodTan =" + objTan.PK_IT_CodTan;
            SqlCommand unComando = new SqlCommand(Select, conexion);
            conexion.Open();
            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {

                objTan.PK_IT_CodTan = Convert.ToInt32(reader[0].ToString());
            }

            conexion.Close();
            return hayRegistros;
        }
        public void ObtenerTanda(DtoTanda objTanda)
        {
            SqlCommand command = new SqlCommand("SP_Buscar_Tanda", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", objTanda.PK_IT_CodTan);
            DataSet ds = new DataSet();
            conexion.Open();
            SqlDataAdapter moldura = new SqlDataAdapter(command);
            moldura.Fill(ds);
            moldura.Dispose();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                objTanda.PK_IT_CodTan = Convert.ToInt32(reader[0].ToString());

                objTanda.VT_TipoTanda = Convert.ToInt32(reader[2].ToString());
                objTanda.VT_Estado = reader[3].ToString();
                objTanda.VT_Descripcion = reader[4].ToString();

            }
            conexion.Close();
            conexion.Dispose();
        }
        public void ObtenerTandaP(DtoTanda objTanda)
        {
            SqlCommand command = new SqlCommand("SP_Buscar_Tanda_P", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", objTanda.PK_IT_CodTan);
            DataSet ds = new DataSet();
            conexion.Open();
            SqlDataAdapter moldura = new SqlDataAdapter(command);
            moldura.Fill(ds);
            moldura.Dispose();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                objTanda.PK_IT_CodTan = Convert.ToInt32(reader[0].ToString());
                //if (reader[1].ToString() != null)
                //{
                //    objTanda.IT_Ganador = Convert.ToInt32(reader[1].ToString());
                //}
                //else
                //{
                //    objTanda.IT_Ganador = 0;
                //}

                objTanda.VT_TipoTanda = Convert.ToInt32(reader[2].ToString());
                objTanda.VT_Estado = reader[3].ToString();
                objTanda.VT_Descripcion = reader[4].ToString();

            }
            conexion.Close();
            conexion.Dispose();
        }
        public DataTable listar_calificados_S(DtoTanda objdtot)
        {
            DataTable dtParticipantes = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Listar_Calificados_S", conexion);
            command.Parameters.AddWithValue("@id", objdtot.PK_IT_CodTan);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtParticipantes = new DataTable();
            daAdaptador.Fill(dtParticipantes);
            conexion.Close();
            return dtParticipantes;
        }
        public void actualizar_estadoT(DtoTanda objT)
        {
            try
            {
                SqlCommand command = new SqlCommand("SP_Actualiza_Estado_Tanda", conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", objT.PK_IT_CodTan);
                conexion.Open();
                command.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void actualizar_ganadorT(DtoTanda objT)
        {
            try
            {
                SqlCommand command = new SqlCommand("SP_Actualiza_Ganador", conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", objT.PK_IT_CodTan);
                command.Parameters.AddWithValue("@ganador", objT.IT_Ganador);
                conexion.Open();
                command.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public DataTable listar_Tanda_NC()
        {
            DataTable dtTanda = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Listar_Tanda_NC", conexion);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtTanda = new DataTable();
            daAdaptador.Fill(dtTanda);
            conexion.Close();
            return dtTanda;
        }
        public void registrarTanda(DtoTanda dtoTanda)
        {
            try
            {
                SqlCommand command = new SqlCommand("SP_RegistrarTanda", conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@tipotanda", dtoTanda.VT_TipoTanda);
                command.Parameters.AddWithValue("@cat", dtoTanda.VT_Descripcion);
                command.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
                conexion.Open();
               
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtoTanda.PK_IT_CodTan = Convert.ToInt32(command.Parameters["@NewId"].Value);
                }
                conexion.Close();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        //mover a DAO_Usuario_modalidad_tanda
        public void registrarUMT(DtoUsuarioModalidadTanda objUMT)
        {
            try
            {
                SqlCommand command = new SqlCommand("SP_Asignar_Tanda", conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", objUMT.PK_IUMT_CodUsuModTan);
                command.Parameters.AddWithValue("@cod", objUMT.PK_IUMT_CodUsuModTan);
                command.Parameters.AddWithValue("@idT", objUMT.PK_IUMT_CodUsuModTan);
                command.Parameters.AddWithValue("@pista", objUMT.PK_IUMT_CodUsuModTan);
                conexion.Open();
                command.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable ListarParticipantesXtanda(DtoUsuarioModalidadTanda objUMT)
        {
            
            DataTable dtParticipantes = null;
            conexion.Open();
            SqlCommand command = new SqlCommand("SP_Obtener_Participante_x_Tanda", conexion);
            command.Parameters.AddWithValue("@idT", objUMT.FK_IT_CodTan);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtParticipantes = new DataTable();
            daAdaptador.Fill(dtParticipantes);
            conexion.Close();
            return dtParticipantes;
        }
        public void actualizar_estado_umt(DtoUsuarioModalidadTanda objUMT)
        {
            try
            {
                SqlCommand command = new SqlCommand("SP_Actualizar_Estado_UMT", conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", objUMT.PK_IUMT_CodUsuModTan);
                conexion.Open();
                command.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public int sumaPuntaje(DtoUsuarioModalidadTanda objUMT)
        {
            try
            {
                SqlCommand command = new SqlCommand("SP_SumarPuntaje_UMT", conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", objUMT.PK_IUMT_CodUsuModTan);
                DataSet ds = new DataSet();
                conexion.Open();
                SqlDataAdapter moldura = new SqlDataAdapter(command);
                moldura.Fill(ds);
                moldura.Dispose();

                SqlDataReader reader = command.ExecuteReader();
                int suma = 0;
                while (reader.Read())
                {
                    suma = Convert.ToInt32(reader[0].ToString());
                }
                conexion.Close();
                return suma;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public void actualizar_PuntajeT_umt(DtoUsuarioModalidadTanda objUMT)
        {
            try
            {
                SqlCommand command = new SqlCommand("SP_Actualiza_PuntajeT", conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", objUMT.PK_IUMT_CodUsuModTan);
                command.Parameters.AddWithValue("@suma", objUMT.IUMT_PuntajeTotal);
                conexion.Open();
                command.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
