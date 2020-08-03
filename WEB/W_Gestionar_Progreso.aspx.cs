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
    public partial class W_Gestionar_Progreso : System.Web.UI.Page
    {
        CtrProgreso objCtrprogreso = new CtrProgreso();
        DtoProgreso objDtoProgreso = new DtoProgreso();
        
        Log _log = new Log();
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
            try
            {
                _log.CustomWriteOnLog("registrar progreso", "1");
               
                _log.CustomWriteOnLog("registrar progreso", txtNombreProgreso.Text);
                objDtoProgreso.VP_NombreProgreso = txtNombreProgreso.Text;
                _log.CustomWriteOnLog("registrar progreso", Convert.ToDouble(txtNota1.Text).ToString());
                objDtoProgreso.DP_NotaPasos = Convert.ToDouble(txtNota1.Text);
                _log.CustomWriteOnLog("registrar progreso", Convert.ToDouble(txtNota2.Text).ToString());
                objDtoProgreso.DP_NotaTecnica = Convert.ToDouble(txtNota2.Text);
                _log.CustomWriteOnLog("registrar progreso", Convert.ToDouble(txtNota3.Text).ToString());
                objDtoProgreso.DP_NotaInteres = Convert.ToDouble(txtNota3.Text);
                _log.CustomWriteOnLog("registrar progreso", Convert.ToDouble(txtNota4.Text).ToString());
                objDtoProgreso.DP_NotaHabilidad = Convert.ToDouble(txtNota4.Text);
                _log.CustomWriteOnLog("registrar progreso", calcularNotas().ToString());
                objDtoProgreso.DP_TotalNota = Convert.ToDouble(txtNotaTotal.Text);
                _log.CustomWriteOnLog("registrar progreso", txtObservacion.Text);
                objDtoProgreso.VP_Observacion = txtObservacion.Text;
                _log.CustomWriteOnLog("registrar progreso", txtObservacion.Text);
                                

                //objDtoProgreso.FK_IA_CodAsi = Convert.ToInt32(); //me falta la fk de la asistencia
                _log.CustomWriteOnLog("registrar progreso", "dato progreso: " + objDtoProgreso.PK_IP_CodProgreso.ToString());
                objCtrprogreso.RegistrarProgresoAlumno(objDtoProgreso);
                string m = "Se registró correctamente el progreso del alumno";

                Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m + "','success')");
            }

            catch (Exception ex)
            {
                _log.CustomWriteOnLog("registrar pago", "Error : " + ex.Message + "Stac" + ex.StackTrace);
            }
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

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            double n1 = double.Parse(txtNota1.Text);
            double n2 = double.Parse(txtNota2.Text);
            double n3 = double.Parse(txtNota3.Text);
            double n4 = double.Parse(txtNota4.Text);
            double total = (n1 + n2 + n3 + n4) / 4;
            txtNotaTotal.Text = total.ToString();
            //txtProgreso.Text = ((total * 100) / 20).ToString() + " %";
        }

        protected void btnCalcular_Click1(object sender, EventArgs e)
        {
            double n1 = double.Parse(txtNota1.Text);
            double n2 = double.Parse(txtNota2.Text);
            double n3 = double.Parse(txtNota3.Text);
            double n4 = double.Parse(txtNota4.Text);
            double total = (n1 + n2 + n3 + n4) / 4;
            txtProgreso.Text = ((total * 100) / 20).ToString() + " %";
            txtNotaTotal.Text = total.ToString();
        }
    }
}