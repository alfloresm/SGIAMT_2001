using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;


namespace WEB
{
    public partial class W_Registrar_Pago : System.Web.UI.Page
    {
        CtrPago objCtrpago = new CtrPago();
        DtoPago objDtoPago = new DtoPago();
        Log _log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _log.CustomWriteOnLog("registrar pago", "cargo: ");

            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            _log.CustomWriteOnLog("registrar pago", "1");
            objDtoPago.PK_IP_CodPago = Convert.ToInt32(txtCodigo.Text);
            objDtoPago.DTP_Fecha = Convert.ToDateTime(txtFecha.Text);
            objDtoPago.DP_Monto = Convert.ToDecimal(devolverMonto());
            objDtoPago.VP_Anio = DateTime.Now.Year.ToString();
            objDtoPago.VP_Mes = Convert.ToString(ddlMes.SelectedValue);
            objDtoPago.VP_Estado = Convert.ToString(ddlEstado.SelectedValue);
            objDtoPago.FK_IU_DNI = Convert.ToString(ddlDNI.SelectedValue);

            _log.CustomWriteOnLog("registrar pago", "dato alumno: " + objDtoPago.PK_IP_CodPago.ToString());
            objCtrpago.RegistrarPago(objDtoPago);
            string m = "Se registró correctamente el pago";

            Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m + "','success')");

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Index.aspx");
        }

        public string devolverMonto()
        {
            if (ddlConceptoPago.SelectedValue=="Mensual")
            {
                return txtMonto.Text = "80.00";
            }
            else
                if (ddlConceptoPago.SelectedValue == "Anual")
            {
                return txtMonto.Text = "30.00";
            }
            else
                if (ddlConceptoPago.SelectedValue == "Total")
            {
                return txtMonto.Text = "110.00";
            }
            else
                return "Seleccione un concepto de pago válido";
        }

        protected void ddlDNI_SelectedIndexChanged(object sender, EventArgs e)
        {
            objCtrpago.devolverDniAlumnos();
        }
    }
}