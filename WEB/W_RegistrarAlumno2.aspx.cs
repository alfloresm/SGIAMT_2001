using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;

namespace WEB
{
    public partial class W_RegistrarAlumno2 : System.Web.UI.Page
    {
        CtrAlumno objctralumno = new CtrAlumno();
        DtoAlumno objDtoAlumno = new DtoAlumno();
        Log _log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _log.CustomWriteOnLog("registrar alumno", "cargo: ");

            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                _log.CustomWriteOnLog("registrar alumno", "1");
                objDtoAlumno.PK_IU_DNI = txtDNI.Text;
                objDtoAlumno.VU_Nombre = txtNombre.Text;
                objDtoAlumno.VU_APaterno = txtApellidoP.Text;
                objDtoAlumno.VU_AMaterno = txtApellidoM.Text;
                objDtoAlumno.DTU_FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
                objDtoAlumno.VU_Contrasenia = txtContrasenia.Text;
                objDtoAlumno.VU_Sexo = Convert.ToString(ddlSexo.SelectedValue);
                objDtoAlumno.VU_NAcademia = txtNombreAcademia.Text;
                objDtoAlumno.VU_Correo = txtCorreo.Text;
                objDtoAlumno.VU_Celular = txtCelular.Text;
                objDtoAlumno.VU_Estado = Convert.ToString(ddlEstado.SelectedValue);
                objDtoAlumno.VU_Horario = Convert.ToString(ddlHorario.SelectedValue);
                objDtoAlumno.VU_Direccion = txtDireccion.Text;
                int anio = objDtoAlumno.DTU_FechaNacimiento.Year;
                objDtoAlumno.FK_ICA_CodCat = objctralumno.devolverCategoria(anio);
                _log.CustomWriteOnLog("registrar alumno", "dato alumno: " + objDtoAlumno.PK_IU_DNI.ToString());
                objctralumno.RegistrarAlumno(objDtoAlumno);
                string m = "Se registró correctamente";

                Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m + "','success')");
            }
            catch(Exception ex)
            {
                _log.CustomWriteOnLog("registrar alumno", "Error : " + ex.Message + "Stac" + ex.StackTrace);
            }

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/W_Index.aspx");
        }
        
    }
}