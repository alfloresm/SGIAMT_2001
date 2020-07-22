using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using CTR;
using DTO;


namespace WEB
{
    public partial class W_Registrar_Pago : System.Web.UI.Page
    {
        CtrPago objCtrpago = new CtrPago();
        DtoPago objDtoPago = new DtoPago();
        DtoConceptoPago objDtoCP = new DtoConceptoPago();
        Log _log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _log.CustomWriteOnLog("registrar pago", "cargo: ");
                llenarDNI();
                llenarConceptoPago();
            }
        }

        public void llenarDNI()
        {
            DataSet ds = new DataSet();
            ds = objCtrpago.desplegableDNI();
            ddlDNI.DataSource = ds;
            ddlDNI.DataTextField = "PK_IU_DNI";
            ddlDNI.DataValueField = "PK_IU_DNI";
            ddlDNI.DataBind();
            ddlDNI.Items.Insert(0, new ListItem("Seleccione", "0"));
        }

        public void llenarConceptoPago()
        {
            DataSet ds = new DataSet();
            ds = objCtrpago.desplegableConceptoPago();
            ddlConceptoPago.DataSource = ds;
            ddlConceptoPago.DataTextField = "VCP_Descripcion";
            ddlConceptoPago.DataValueField = "PK_ICP_CodConP";
            ddlConceptoPago.DataBind();
            ddlConceptoPago.Items.Insert(0, new ListItem("Seleccione", "0"));
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                _log.CustomWriteOnLog("registrar pago", "1");
                //objDtoPago.PK_IP_CodPago = Convert.ToInt32(txtCodigo.Text);
                _log.CustomWriteOnLog("registrar pago", DateTime.Now.ToString());
                objDtoPago.DTP_Fecha = DateTime.Now;
                _log.CustomWriteOnLog("registrar pago", txtMonto.Text);
                objDtoPago.DP_Monto = Convert.ToDouble(txtMonto.Text);
                _log.CustomWriteOnLog("registrar pago", DateTime.Now.Year.ToString());
                objDtoPago.VP_Anio = DateTime.Now.Year.ToString();
                _log.CustomWriteOnLog("registrar pago", Convert.ToString(ddlMes.SelectedValue));
                objDtoPago.VP_Mes = Convert.ToString(ddlMes.SelectedValue);
                 objDtoPago.VP_Estado = "";
                _log.CustomWriteOnLog("registrar pago", Convert.ToString(ddlDNI.SelectedValue));
                objDtoPago.FK_IU_DNI= Convert.ToString(ddlDNI.SelectedValue);
                _log.CustomWriteOnLog("registrar pago", Convert.ToInt32(ddlConceptoPago.SelectedValue).ToString());
                objDtoPago.FK_ICP_Cod = Convert.ToInt32(ddlConceptoPago.SelectedValue);
                _log.CustomWriteOnLog("registrar pago", "dato pago: " + objDtoPago.PK_IP_CodPago.ToString());
                objCtrpago.RegistrarPago(objDtoPago);
                string m = "Se registró correctamente el pago";

                Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m + "','success')");
            }

            catch (Exception ex)
            {
                _log.CustomWriteOnLog("registrar pago", "Error : " + ex.Message + "Stac" + ex.StackTrace);
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Index.aspx");
        }

        //protected void ddlConceptoPago_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    _log.CustomWriteOnLog("registrar pago", "10");
        //    DtoConceptoPago dtoConceptoPago = new DtoConceptoPago();
        //    dtoConceptoPago.PK_ICP_CodCodP = Convert.ToInt32(ddlConceptoPago.SelectedValue);
        //    _log.CustomWriteOnLog("registrar pago", Convert.ToInt32(ddlConceptoPago.SelectedValue).ToString());
        //    double monto = objCtrpago.obtenerMontoPago(dtoConceptoPago.PK_ICP_CodCodP);
        //    _log.CustomWriteOnLog("registrar pago", monto.ToString());
        //    txtMonto.Text = monto.ToString();
        //    updPanel2.Update();
        //}

        protected void btnMonto_Click(object sender, EventArgs e)
        {
            _log.CustomWriteOnLog("registrar pago", "10");
            DtoConceptoPago dtoConceptoPago = new DtoConceptoPago();
            dtoConceptoPago.PK_ICP_CodCodP = Convert.ToInt32(ddlConceptoPago.SelectedValue);
            _log.CustomWriteOnLog("registrar pago", Convert.ToInt32(ddlConceptoPago.SelectedValue).ToString());
            double monto = objCtrpago.obtenerMontoPago(dtoConceptoPago.PK_ICP_CodCodP);
            _log.CustomWriteOnLog("registrar pago", monto.ToString());
            txtMonto.Text = monto.ToString();
            updPanel2.Update();
        }

    }
}