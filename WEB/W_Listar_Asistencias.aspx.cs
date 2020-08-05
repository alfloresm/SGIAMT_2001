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
    public partial class W_Listar_Asistencias : System.Web.UI.Page
    {
        CtrAlumno objctrAlumno = new CtrAlumno();
        DtoUsuario objdtoalumno = new DtoUsuario();
        DtoAsistencia objdtoAsis = new DtoAsistencia();
        CtrAsistencia objctrAsistencia = new CtrAsistencia();
      
        Log _log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            GVAsistencia.DataSource = objctrAsistencia.ListarAsistencias_();
            GVAsistencia.DataBind();
        }

        protected void GVAsistencia_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVAsistencia.DataSource = objctrAsistencia.ListarAsistencias_();
            GVAsistencia.DataBind();
        }

        protected void GVAsistencia_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/W_Listar_Alumnos.aspx");
        }
    }
}