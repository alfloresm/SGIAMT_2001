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
    public class DaoPuntaje
    {
        SqlConnection conexion;
        public DaoPuntaje()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void registrar_Puntaje(DtoPuntaje objdtopuntaje)
        {
            try
            {

                SqlCommand command = new SqlCommand("SP_Registrar_Puntaje", conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idUMT", objdtopuntaje.FK_IUMT_UsuModTan);
                command.Parameters.AddWithValue("@njurado", objdtopuntaje.IP_NumeroJurado);
                command.Parameters.AddWithValue("@puntaje", objdtopuntaje.IP_Puntaje);
                conexion.Open();
                command.ExecuteNonQuery();
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool existePuntaje(DtoPuntaje objdtopuntaje)
        {
            string Select = "SELECT * from T_Puntaje where FK_IUMT_UsuModTan ='" + objdtopuntaje.FK_IUMT_UsuModTan+ "' and IP_NumeroJurado="+ objdtopuntaje.IP_NumeroJurado;
            SqlCommand unComando = new SqlCommand(Select, conexion);
            conexion.Open();
            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {

                objdtopuntaje.PK_IP_Cod= Convert.ToInt32(reader[0].ToString());
            }

            conexion.Close();
            return hayRegistros;
        }
        public void actualizar_Puntaje(DtoPuntaje objdtopuntaje)
        {
            try
            {

                SqlCommand command = new SqlCommand("SP_Actualizar_Puntaje", conexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idUMT", objdtopuntaje.FK_IUMT_UsuModTan);
                command.Parameters.AddWithValue("@njurado", objdtopuntaje.IP_NumeroJurado);
                command.Parameters.AddWithValue("@puntaje", objdtopuntaje.IP_Puntaje);
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
