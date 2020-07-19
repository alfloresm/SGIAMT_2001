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
            command.Parameters.AddWithValue("@estado", objPago.VP_Estado);
            command.Parameters.AddWithValue("@dni", objPago.FK_IU_DNI);
 
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

        public string obtenerAnio()
        {
            return DateTime.Now.Year.ToString();
        }
    }
}
