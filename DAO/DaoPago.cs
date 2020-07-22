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
    public class DaoPago
    {
        SqlConnection conexion;
        public DaoPago()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void RegistrarPago(DtoPago objPago)
        {

            SqlCommand command = new SqlCommand("SP_RegistrarPago", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@fecha", objPago.DTP_Fecha);
            command.Parameters.AddWithValue("@monto", objPago.DP_Monto);
            command.Parameters.AddWithValue("@anio", objPago.VP_Anio);
            command.Parameters.AddWithValue("@mes", objPago.VP_Mes);
            command.Parameters.AddWithValue("@dni", objPago.FK_IU_DNI);
            command.Parameters.AddWithValue("@concepto", objPago.FK_ICP_Cod);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }
        public void ObtenerDNI()
        {
                SqlCommand command = new SqlCommand("select PK_IU_DNI from T_Usuario", conexion);
                conexion.Open();
                command.ExecuteNonQuery();
                conexion.Close();
        }

        public DataSet desplegarDni()
        {
            SqlDataAdapter listadni = new SqlDataAdapter("SP_Desplegable_Dni", conexion);
            listadni.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet DS = new DataSet();
            listadni.Fill(DS);
            return DS;
        }

        public DataSet desplegarConceptoPago()
        {
            SqlDataAdapter listaConcepto = new SqlDataAdapter("SP_DesplegableConceptoPago", conexion);
            listaConcepto.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet DS = new DataSet();
            listaConcepto.Fill(DS);
            return DS;
        }

        public double ObtenerMonto(int codigo)
        {
            try
            {
                double valor_retornado = 0.0;
                SqlCommand cmd = new SqlCommand("select DCP_Monto from T_Concepto_Pago where PK_ICP_CodConP =" + codigo, conexion);
                Console.WriteLine(cmd);
                conexion.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    valor_retornado= double.Parse(reader[0].ToString());
                }
                conexion.Close();
                return valor_retornado;
            }
            catch (Exception)
            {
                throw;

            }
        }

        //mostrar los nombres concatenados
        public void ObtenerDatosAlumno(DtoUsuario objUsuario, DtoCategoria objcat)
        {
            SqlCommand command = new SqlCommand("SP_ObtenerParticipante_I", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@dni", objUsuario.PK_IU_DNI);
            DataSet ds = new DataSet();
            conexion.Open();
            SqlDataAdapter comando = new SqlDataAdapter(command);
            comando.Fill(ds);
            comando.Dispose();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                objUsuario.nombres = reader[0].ToString();
                objcat.PK_ICA_CodCat = Convert.ToInt32(reader[1].ToString());
                objcat.VCA_NomCategoria = reader[2].ToString();
                
            }
            conexion.Close();
            conexion.Dispose();
        }
    }

}
