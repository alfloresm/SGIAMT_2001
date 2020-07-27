using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
using System.Net.Mail;
using System.Net;
namespace DAO
{
    public class DaoUsuario
    {
        SqlConnection conexion;
        public DaoUsuario()
        {
            conexion = new SqlConnection(ConexionBD.CadenaConexion);
        }
        public void EnviarCorreoInscripcion(DtoUsuarioxModalidad objuxm)
        {
            SqlCommand command = new SqlCommand("SP_ObtenerDatoCorreo", conexion);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@cod", objuxm.PK_IUM_CodUM);
            DataSet ds = new DataSet();
            conexion.Open();
            SqlDataAdapter moldura = new SqlDataAdapter(command);
            moldura.Fill(ds);
            moldura.Dispose();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                string senderr = "tusuyperu2020@gmail.com";
                string senderrPass = "20Tusuyperu20";
                string displayName = "Academia de marinera TusuyPeru";

                var nombre1 = reader["NombrePrincipal"].ToString();
                var correo1 = reader["CorreoPrincipal"].ToString();
                var nombre2 = reader["NombrePareja"].ToString();
                var correo2 = reader["CorreoPareja"].ToString();
                var nombreC = reader["VC_NombreCon"].ToString();
                var lugarC = reader["VC_LugarCon"].ToString();
                var monto = reader["DI_Monto"].ToString();
                var fecha = reader["DTUM_FechaIns"].ToString();
                var modalidad = reader["VM_NombreMod"].ToString();
                var codigo = reader["PK_IUM_CodUM"].ToString();

                MailMessage mail = new MailMessage();
                if (objuxm.FK_IM_IdModalidad==1) { 
                string body =
                    "<body>" +
                        "<h2>Hola "+nombre1+"</h2>" +
                        "<h4>Tu inscripcion al concurso "+nombreC+",que se realizara en "+lugarC+" ha sido realizada correctamente el dia "+ fecha + "</h4>" +
                        "<br></br><h4>Su informacion es la siguiente:</h4>" +
                        "<br></br><span>Monto de inscripcion: " + monto + "</span>" +
                        "<br></br><span>Modalidad: " + modalidad + "</span>" +
                        "<br></br><h3>recuerde que su numero de participante es: " + codigo + "</h3>" +
                        "<br></br><span> Saludos cordiales.<span>" +
                        "<br></br><span> TusuyPeru.<span>" +
                    "</body>";
                   
                    mail.Subject = "Inscripcion Correcta";
                    mail.From = new MailAddress(senderr.Trim(), displayName);
                    mail.Body = body;
                    mail.To.Add(correo1.Trim());
                }
                else if (objuxm.FK_IM_IdModalidad==2)
                {
                    string body =
                    "<body>" +
                        "<h2>Hola " + nombre1 + " y "+nombre2+"</h2>" +
                        "<h4>Tu inscripcion al concurso " + nombreC + ",que se realizara en " + lugarC + " ha sido realizada correctamente el dia " + fecha + "</h4>" +
                        "<br></br><h4>Su informacion es la siguiente:</h4>" +
                        "<br></br><span>Monto de inscripcion: " + monto + "</span>" +
                        "<br></br><span>Modalidad: " + modalidad + "</span>" +
                        "<br></br><h3>recuerde que su numero de participante es: " + codigo + "</h3>" +
                        "<br></br><span> Saludos cordiales.<span>" +
                        "<br></br><span> TusuyPeru.<span>" +
                    "</body>";
                    mail.Subject = "Inscripcion Correcta";
                    mail.From = new MailAddress(senderr.Trim(), displayName);
                    mail.Body = body;
                    mail.To.Add(correo1.Trim());
                    mail.CC.Add(correo2.Trim());
                }                
                mail.IsBodyHtml = true;
                //mail.Priority = MailPriority.Normal;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtp.Credentials = new System.Net.NetworkCredential(senderr.Trim(), senderrPass.Trim());
                NetworkCredential nc = new NetworkCredential(senderr, senderrPass);
                smtp.Credentials = nc;

                smtp.Send(mail);
                
            }
            conexion.Close();
        }
        public int validacionLogin(string usuario, string clave)
        {

            int valor_retornado = 0;
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM T_USUARIO as U WHERE" +
                " U.PK_IU_DNI = '" + usuario + "' AND U.VU_Contrasenia = '" + clave + "'", conexion);



            Console.WriteLine(cmd);
            conexion.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {    //valor_retornado = reader[0].ToString();
                valor_retornado = int.Parse(reader[0].ToString());

            }
            conexion.Close();

            return valor_retornado;
        }

        public DtoUsuario datosUsuario(String usuario)
        {
            SqlCommand cmd = new SqlCommand("select U.FK_ITU_TipoUsuario," +
                "U.VU_Nombre," +
                "U.VU_APaterno," +
                "U.VU_AMaterno," +
                "U.VU_Correo," +
                "U.VU_Sexo," +
                "U.VU_NAcademia," +
                "U.PK_IU_DNI," +
                "U.VU_Celular," +
                "U.VU_Estado," +
                "U.VU_Horario," +
                "U.FK_ICA_CodCat" +
                " from T_Usuario as U " +
                "where U.PK_IU_DNI = '" + usuario + "'", conexion);

            DtoUsuario usuarioDto = new DtoUsuario();
            DtoTipoUsuario tipousuarioDto = new DtoTipoUsuario();



            conexion.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                tipousuarioDto.PK_ITU_TipoUsuario = int.Parse(reader[0].ToString());
                usuarioDto.FK_ITU_TipoUsuario = int.Parse(reader[0].ToString());
                usuarioDto.VU_Nombre = reader[1].ToString();
                usuarioDto.VU_APaterno = reader[2].ToString();
                usuarioDto.VU_AMaterno = reader[3].ToString();
                usuarioDto.VU_Correo = reader[4].ToString();
                usuarioDto.VU_Sexo = reader[5].ToString();
                usuarioDto.VU_NAcademia = reader[6].ToString();
                usuarioDto.PK_IU_DNI = reader[7].ToString();
                usuarioDto.VU_Celular = reader[8].ToString();
                usuarioDto.VU_Estado = reader[9].ToString();
                usuarioDto.VU_Horario = reader[10].ToString();
                usuarioDto.FK_ICA_CodCat = int.Parse(reader[11].ToString());

            }
            conexion.Close();

            return (usuarioDto);
        }
    }
}
