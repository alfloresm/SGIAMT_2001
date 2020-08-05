using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;

namespace WEB.MASTER_EXTERNO
{
    public partial class W_RegistrarParticipante : System.Web.UI.Page
    {
        Log _log = new Log();
        CtrParticipante objCtrParticipante = new CtrParticipante();
        DtoUsuario objdtoUsuario = new DtoUsuario();
        CtrAlumno objCtrAlumno = new CtrAlumno();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    _log.CustomWriteOnLog("Registrar Participante", "***Cargo****");
                }
            }
            catch (Exception ex)
            {

                _log.CustomWriteOnLog("Registrar Participante", "Error : " + ex.Message + "Stac" + ex.StackTrace);
            }

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
         
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                objdtoUsuario.PK_IU_DNI = txtDNI.Text;
                if (!objCtrParticipante.existeUsuarioAca(objdtoUsuario))
                {
                    if (!objCtrParticipante.existeUsuario(objdtoUsuario))
                    {
                        DateTime a= Convert.ToDateTime(txtFechaNacimiento.Text);
                        if (a.Year < 2017)
                        {
                            _log.CustomWriteOnLog("Registrar Participante", "entra a boton registrar");
                            objdtoUsuario.VU_Nombre = txtNombre.Text;
                            objdtoUsuario.VU_APaterno = txtApellidoP.Text;
                            objdtoUsuario.VU_AMaterno = txtApellidoM.Text;
                            if (rbFemenino.Checked)
                            {
                                objdtoUsuario.VU_Sexo = "femenino";
                            }
                            else if (rbMasculino.Checked)
                            {
                                objdtoUsuario.VU_Sexo = "masculino";
                            }
                            objdtoUsuario.VU_NAcademia = txtNombreAcademia.Text;
                            objdtoUsuario.VU_Celular = txtCelular.Text;
                            objdtoUsuario.DTU_FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
                            objdtoUsuario.VU_Correo = txtCorreo.Text;
                            objdtoUsuario.VU_Contrasenia = txtContraseña.Text;

                            int anio = objdtoUsuario.DTU_FechaNacimiento.Year;
                            objdtoUsuario.FK_ICA_CodCat = objCtrAlumno.devolverCategoria(anio);
                            objCtrParticipante.registrarParticipante(objdtoUsuario);
                            _log.CustomWriteOnLog("Registrar Participante", "DNI:" + objdtoUsuario.PK_IU_DNI.ToString());
                            string id = objdtoUsuario.PK_IU_DNI.ToString();
                            Utils.AddScriptClientUpdatePanel(upBotonEnviar, "uploadFileDocuments(" + id + ");");
                            limpiar();
                            _log.CustomWriteOnLog("Registrar Participante", "Agregado");
                            string m = "Usuario registrado correctamente";
                            Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m + "','success')");
                            _log.CustomWriteOnLog("Registrar Participante", "terminado");
                            //Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showSuccessMessage2()");
                        }
                        else
                        {
                            string m = "Año fuera de rango";
                            Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m + "','danger')");
                        }

                    }
                    else
                    {
                        string m = "Usuario ya registrado en la academia";
                        Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m + "','danger')");
                    }
                }
                else
                {
                    string m = "Usuario ya registrado como participante";
                    Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m + "','danger')");
                }
            }
            catch (Exception ex)
            {

                _log.CustomWriteOnLog("Registrar Participante", "Error : " + ex.Message + "Stac" + ex.StackTrace);
            }
        }
        public void limpiar()
        {
            txtDNI.Text = "";
            txtNombre.Text = "";
            txtApellidoM.Text = "";
            txtApellidoP.Text = "";
            txtCelular.Text = "";
            txtcontra2.Text = "";
            txtContraseña.Text = "";
            txtCorreo.Text = "";
            txtFechaNacimiento.Text = "";
            txtNombreAcademia.Text = "";
            rbFemenino.Checked = false;
            rbMasculino.Checked = false;
        }
    }
}