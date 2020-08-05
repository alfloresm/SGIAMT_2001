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
    public partial class W_Listar_Progresos : System.Web.UI.Page
    {
        CtrAlumno objctrAlumno = new CtrAlumno();
        DtoUsuario objdtoalumno = new DtoUsuario();
        DtoAsistencia objdtoAsis = new DtoAsistencia();
        CtrProgreso objctrprogreso = new CtrProgreso();
        Log _log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            GVProgreso.DataSource = objctrprogreso.ListarProgresos_();
            GVProgreso.DataBind();
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/W_Listar_Alumnos.aspx");
        }

        protected void GVProgreso_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVProgreso.DataSource = objctrprogreso.ListarProgresos_();
            GVProgreso.DataBind();
        }

        protected void GVProgreso_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}