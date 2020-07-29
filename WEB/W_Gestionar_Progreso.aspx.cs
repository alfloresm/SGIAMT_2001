using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB
{
    public partial class W_Gestionar_Progreso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["Id"] != null)
                {

                    txtPagina.InnerText = "Actualizar Progreso";
                    btnRegistrar.Text = "Actualizar";
                    //Panel1.Visible = true;
                    //Panel2.Visible = true;
                    //obtenerConcurso(Request.Params["Id"]);

                }
                else
                {
                    txtPagina.InnerText = "Registrar Progreso";
                    btnRegistrar.Text = "Registrar";
                    //Panel1.Visible = false;
                    //Panel2.Visible = false;
                }
            }

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {

        }
        
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/W_Listar_Alumnos.aspx");
        }

        public double calcularNotas()
        {
            double n1 = double.Parse(txtNota1.Text);
            double n2 = double.Parse(txtNota2.Text);
            double n3 = double.Parse(txtNota3.Text);
            double n4 = double.Parse(txtNota4.Text);
            double total = (n1 + n2 + n3 + n4) / 4;
            txtNotaTotal.Text = total.ToString();
            txtProgreso.Text =((total * 100) / 20).ToString()+" %";
            return total;
        }
    }
}