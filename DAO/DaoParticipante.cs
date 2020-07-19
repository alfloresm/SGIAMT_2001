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
    public class DaoParticipante
    {
        SqlConnection conexion;
        public DaoParticipante()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void ObtenerParticipante(DtoUsuario objUsuario,DtoCategoria objcat)
        { SqlCommand command = new SqlCommand("SP_ObtenerParticipante_I", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@dni", objUsuario.PK_IU_DNI);
            DataSet ds = new DataSet();
            conexion.Open();
            SqlDataAdapter moldura = new SqlDataAdapter(command);
            moldura.Fill(ds);
            moldura.Dispose();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                objUsuario.nombres= reader[0].ToString();
                objcat.PK_ICA_CodCat = Convert.ToInt32(reader[1].ToString());
                objcat.VCA_NomCategoria= reader[2].ToString();
                objUsuario.VU_Sexo= reader[3].ToString();
            }
            conexion.Close();
            conexion.Dispose();
        }
        public void ObtenerPareja(DtoUsuario objUsuario)
        {

        }
        public bool SelectUsuario(DtoUsuario objuser)//encuentra usuario con ese dni
        {
            string Select = "SELECT * from T_Usuario where PK_IU_DNI ='" + objuser.PK_IU_DNI + "'";
            SqlCommand unComando = new SqlCommand(Select, conexion);
            conexion.Open();
            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {

                objuser.PK_IU_DNI = (string)reader[0];
            }
            
            conexion.Close();
            return hayRegistros;
        }
        public bool SelectUsuario_Aca(DtoUsuario objuser)//encuentra usuario con ese dni diferente a la acedemia
        {
            string Select = "SELECT * from T_Usuario where PK_IU_DNI ='" + objuser.PK_IU_DNI + "' AND VU_NAcademia<>'TUSUY PERU' and FK_ITU_TipoUsuario=2";
            SqlCommand unComando = new SqlCommand(Select, conexion);
            conexion.Open();
            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {

                objuser.PK_IU_DNI = (string)reader[0];
            }

            conexion.Close();
            return hayRegistros;
        }
        public bool SelectUsuario_Gen(DtoUsuario objuser,string gen)//encuentra usuario con ese dni diferente al genero
        {
            string Select = "SELECT * from T_Usuario where PK_IU_DNI ='" + objuser.PK_IU_DNI + "' AND VU_Sexo<>'"+gen+"'";
            SqlCommand unComando = new SqlCommand(Select, conexion);
            conexion.Open();
            SqlDataReader reader = unComando.ExecuteReader();
            bool hayRegistros = reader.Read();
            if (hayRegistros)
            {

                objuser.PK_IU_DNI = (string)reader[0];
            }

            conexion.Close();
            return hayRegistros;
        }
    }
}
