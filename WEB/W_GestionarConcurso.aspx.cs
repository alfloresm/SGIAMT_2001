using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DTO;
using CTR;


namespace WEB
{
    public partial class W_GestionarConcurso : System.Web.UI.Page
    {
        CtrConcurso objctrConcurso = new CtrConcurso();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                GVConcurso.DataSource = objctrConcurso.ListaConcursos_();
                GVConcurso.DataBind();

            }

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("W_RegistrarConcurso.aspx");
        }

        protected void btnActualizarCat_Click(object sender, EventArgs e)
        {

        }

        protected void GVConcurso_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVConcurso.DataSource = objctrConcurso.ListaConcursos_();
            GVConcurso.DataBind();
        }

        protected void GVConcurso_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Detalle")
            {

            }
            else if (e.CommandName == "Actualizar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                var colsNoVisible = GVConcurso.DataKeys[index].Values;
                string id = colsNoVisible[0].ToString();
                Response.Redirect("~/W_RegistrarConcurso.aspx?ID=" + id);
            }
        }
    }
}