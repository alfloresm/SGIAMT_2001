using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB
{
    public partial class W_RegistrarConcurso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["Id"] != null)
                {

                    txtPagina.InnerText = "Actualizar Concurso";


                }
                else
                {
                    txtPagina.InnerText = "Registrar Concurso";
                }
            }
        }
    }
}