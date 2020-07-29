﻿using System;
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
    }
}
