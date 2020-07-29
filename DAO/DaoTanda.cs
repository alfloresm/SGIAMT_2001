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

        public DaoTanda() {
            conexion= new SqlConnection(ConexionBD.CadenaConexion);
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
                objTanda.PK_IT_CodTan= Convert.ToInt32(reader[0].ToString());
                
                objTanda.VT_TipoTanda = Convert.ToInt32(reader[2].ToString());
                objTanda.VT_Estado = reader[3].ToString();
                objTanda.VT_Descripcion= reader[4].ToString();
                
            }
            conexion.Close();
            conexion.Dispose();
        }
        public DataTable ListarParticipantesXtanda(DtoUsuarioModalidadTanda objUMT)
        {
            SqlConnection con = new SqlConnection(@"data source=ALE\SQLEXPRESS; initial catalog=BD_SGIAMT; integrated security=SSPI;");
            DataTable dtParticipantes = null;
            con.Open();
            SqlCommand command = new SqlCommand("SP_Obtener_Participante_x_Tanda", con);
            command.Parameters.AddWithValue("@idT", objUMT.FK_IT_CodTan);
            SqlDataAdapter daAdaptador = new SqlDataAdapter(command);
            command.CommandType = CommandType.StoredProcedure;
            dtParticipantes = new DataTable();
            daAdaptador.Fill(dtParticipantes);
            con.Close();
            return dtParticipantes;
        }

    }
}
