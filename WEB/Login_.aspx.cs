using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using DTO;
using DAO;
using CTR;

namespace WEB
{
    public partial class Login_ : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session.Clear();
            //Session.Remove("id_perfil");
            //Session.Abandon();
            //HttpContext.Current.Session.Abandon();
            //Session.RemoveAll();
            //Session["id_perfil"] = null;

        }
        DtoUsuario usr = new DtoUsuario();
        Log log = new Log();

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string dni = txtDni.Text;
            string pass = txtPassword.Text;

            DtoUsuario usuarioDto = new DtoUsuario();
            CtrUsuario usuarioCtr = new CtrUsuario();

            usuarioDto.PK_IU_DNI = dni;
            usuarioDto.VU_Contrasenia = pass;

            usuarioDto = usuarioCtr.Login(usuarioDto);
            log.CustomWriteOnLog("Login_", "usuarioDto" + usuarioDto);
            if (usuarioDto != null)
            {
                log.CustomWriteOnLog("Login_", "-------------------------------------------------------------------------------------------------------------");
                log.CustomWriteOnLog("Login_", "-----------------------------Ingresando a login y seteando valores de session--------------------------------");
                log.CustomWriteOnLog("Login_", "------------------------------------------------------------------------------------------------------------");
                Session["id_perfil"] = usuarioDto.FK_ITU_TipoUsuario;
                log.CustomWriteOnLog("Login_", " Session['id_perfil'] " + Session["id_perfil"]);
                Session["DNIUsuario"] = usuarioDto.PK_IU_DNI;
                Session["NombreUsuario"] = usuarioDto.VU_Nombre;
                Session["ApellidoP"] = usuarioDto.VU_APaterno;
                Session["ApellidoM"] = usuarioDto.VU_AMaterno;
                Session["Genero"]= usuarioDto.VU_Sexo;
                Session["NAcademia"] = usuarioDto.VU_NAcademia;
                Session["CorreoUsuario"] = usuarioDto.VU_Correo;
                Session["FechaNacUsuario"] = usuarioDto.DTU_FechaNacimiento;
                Session["CelularUsuario"] = usuarioDto.VU_Celular;
                Session["Categoria"] = usuarioDto.FK_ICA_CodCat;
                
                //*********HAY QUE CREAR USUARIOS GERENTE Y RECEPCIONISTA***********************
                if (Session["id_perfil"].ToString() == "4")
                {
                    string script = @"<script type='text/javascript'>
                                      location.href='../W_RegistrarAlumno2.aspx';
                                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                }
                else if(Session["id_perfil"].ToString() == "3")
                {
                    string script = @"<script type='text/javascript'>
                                      location.href='../W_GestionarConcurso.aspx';
                                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                }
                else if (Session["id_perfil"].ToString() == "5")
                {
                    string script = @"<script type='text/javascript'>
                                      location.href='../W_Calificar_Participante.aspx';
                                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                }
                else if (Session["id_perfil"].ToString() == "6")
                {
                    string script = @"<script type='text/javascript'>
                                      location.href='../W_Listar_Alumnos.aspx';
                                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                }
                else if (Session["id_perfil"].ToString() == "7")
                {
                    string script = @"<script type='text/javascript'>
                                      location.href='../W_Inscribir_ParticipanteP.aspx';
                                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                }
                else if (Session["id_perfil"].ToString() == "8")
                {
                    string script = @"<script type='text/javascript'>
                                      location.href='../W_Mostrar_Resultado.aspx';
                                  </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
                }
                Session.Timeout = 60;
            }
            else
            {
                log.CustomWriteOnLog("Login_", "---------------------------ERROR---------------------------------------------------");
                txtDni.Text = "";
                txtPassword.Text = "";
                Utils.AddScriptClientUpdatePanel(UpdatePanel, "showErrorMessage()");
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mensaje", "swal({icon: 'error',title: 'ERROR!',text: 'Su usuario o contraseña es incorrecta o no existe'});", true);
                
            }
            }
        }
}