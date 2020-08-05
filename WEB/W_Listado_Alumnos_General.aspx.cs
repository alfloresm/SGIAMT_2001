using System.Data;
using DTO;
using CTR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB
{
    public partial class W_Listado_Alumnos_General : System.Web.UI.Page
    {
        CtrAlumno objctrAlumno = new CtrAlumno();
        DtoUsuario objdtoalumno = new DtoUsuario();
        DtoAsistencia objdtoAsis = new DtoAsistencia();
        CtrAsistencia objctrAsistencia = new CtrAsistencia();

        Log _log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            GVAlumnosTotal.DataSource = objctrAlumno.ListarAlumnosTodos_();
            GVAlumnosTotal.DataBind();
        }

        protected void GVAlumnosTotal_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVAlumnosTotal.DataSource = objctrAlumno.ListarAlumnosTodos_();
            GVAlumnosTotal.DataBind();
        }

        protected void GVAlumnosTotal_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btnIrARegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/W_RegistrarAlumno2.aspx");
        }
    }
}