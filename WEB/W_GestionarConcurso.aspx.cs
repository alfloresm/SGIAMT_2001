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
        CtrConcurso objctrConcurso=new CtrConcurso();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    UpdatePanel.Update();
                    gvConcurso.DataSource = objctrConcurso.ListaMolduras();
                    gvConcurso.DataBind();
                }
                catch(Exception ex)
                {

                }
             }

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("W_RegistrarConcurso.aspx");
        }

        protected void btnActualizarCat_Click(object sender, EventArgs e)
        {

        }
        protected void gvConcurso_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ver")
            {
                try
                {
                }
                catch
                {

                }
            }
            else if (e.CommandName == "Actualizar")
            {
            }
        }
      
    }
}