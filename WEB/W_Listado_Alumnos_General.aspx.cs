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
            if (!IsPostBack)
            {
                GVAlumnosTotal.DataSource = objctrAlumno.ListarAlumnosTodos_();
                GVAlumnosTotal.DataBind();
            }
        }

        protected void GVAlumnosTotal_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVAlumnosTotal.DataSource = objctrAlumno.ListarAlumnosTodos_();
            GVAlumnosTotal.DataBind();
        }

        //protected void GVAlumnosTotal_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        _log.CustomWriteOnLog("listar alumno", "1");
        //        if (e.CommandName == "Actualizar")
        //        {
        //            _log.CustomWriteOnLog("listar alumno", "2");

        //           int index = Convert.ToInt32(e.CommandArgument.ToString());
        //            var colsNoVisible = GVAlumnosTotal.DataKeys[index].Values;
        //            string id = colsNoVisible[0].ToString();
        //            _log.CustomWriteOnLog("listar alumno", "id: "+id);
        //            //Session["act_alu"] = id;
        //            string script = @"<script type='text/javascript'>
        //                              location.href='../W_RegistrarAlumno2.aspx?ID="+id+";</script>";
        //            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", script, false);
        //            //Response.Redirect("~/W_RegistrarAlumno2.aspx?ID=" + id);

        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        _log.CustomWriteOnLog("listar alumno", "Error : " + ex.Message + "Stac" + ex.StackTrace);
        //    }

        //}

        protected void btnIrARegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/W_RegistrarAlumno2.aspx");
        }

        protected void GVAlumnosTotal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                _log.CustomWriteOnLog("listar alumno", "1");
                if (e.CommandName == "Actualizar")
                {
                    _log.CustomWriteOnLog("listar alumno", "2");

                    int index = Convert.ToInt32(e.CommandArgument.ToString());
                    var colsNoVisible = GVAlumnosTotal.DataKeys[index].Values;
                    string id = colsNoVisible[0].ToString();
                    _log.CustomWriteOnLog("listar alumno", "id: " + id);
                    Session["act_alu"] = id;
                    
                    Response.Redirect("~/W_RegistrarAlumno2.aspx");

                }
            }

            catch (Exception ex)
            {
                _log.CustomWriteOnLog("listar alumno", "Error : " + ex.Message + "Stac" + ex.StackTrace);
            }
        }
    }
}