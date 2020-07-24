using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;

namespace WEB
{
    public partial class W_Administrar_Asistencia_Alumno : System.Web.UI.Page
    {
        CtrAlumno objctrAlumno = new CtrAlumno();
        DtoUsuario objdtoalumno = new DtoUsuario();
        Log _log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            GVAlumnos.DataSource = objctrAlumno.ListaAlumnos_();
            GVAlumnos.DataBind();
        }

        protected void GVAlumnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVAlumnos.DataSource = objctrAlumno.ListaAlumnos_();
            GVAlumnos.DataBind();
        }

    }
}