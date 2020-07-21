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
    public class DaoInscripcion
    {
        SqlConnection conexion;
        public DaoInscripcion()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void registrarInscripcionP(DtoInscripcion objdtoInscripcion)
        {
            try { 

            SqlCommand command = new SqlCommand("SP_RegistrarInscripcion", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@monto", objdtoInscripcion.DI_Monto);
            command.Parameters.AddWithValue("@id", objdtoInscripcion.FK_IUM_CodUm);

            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
