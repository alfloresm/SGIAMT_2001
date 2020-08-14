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
    public partial class W_Asignar_Tanda : System.Web.UI.Page
    {
        DtoUsuarioModalidadTanda objumt = new DtoUsuarioModalidadTanda();
        DtoTanda objtanda = new DtoTanda();
        CtrTanda objctrtanda = new CtrTanda();
        Log _log = new Log();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                _log.CustomWriteOnLog("asignar tanda", "Carga Página");
                try
                {
                    if (Session["DNIUsuario"] != null)
                    {
                        pnlPistas.Visible = false;
                        txtCodPista1.Text = "";
                        txtCodPista2.Text = "";
                        txtCodPista3.Text = "";
                        txtCodPista4.Text = "";
                    }
                    else
                    {
                        Response.Redirect("Login_.aspx");
                    }

                }
                catch (Exception ex)
                {
                    _log.CustomWriteOnLog("asignar tanda", "Error : " + ex.Message + "Stac" + ex.StackTrace);
                }
            }
        }

        protected void btnIr_Click(object sender, EventArgs e)
        {
            try
            {
                objtanda.VT_TipoTanda = Convert.ToInt32(ddlModalidad.SelectedValue);
                objtanda.VT_Descripcion = ddlCat.SelectedValue.ToString();
                objctrtanda.regTanda(objtanda);
                _log.CustomWriteOnLog("asignar tanda", "registra tanda");
                _log.CustomWriteOnLog("asignar tanda", "codigo : " + objtanda.PK_IT_CodTan);
                HFidTanda.Value = objtanda.PK_IT_CodTan.ToString();
                txtCodPista1.Text = "";
                txtCodPista2.Text = "";
                txtCodPista3.Text = "";
                txtCodPista4.Text = "";
                pnlPistas.Visible = true;

            }
            catch (Exception ex)
            {

                _log.CustomWriteOnLog("asignar tanda", "Error : " + ex.Message + "Stac" + ex.StackTrace);
            }

        }

        protected void BtnPista1_Click(object sender, EventArgs e)
        {
            try
            {
                _log.CustomWriteOnLog("asignar tanda", "entra boton pista 1");
                objumt.IUMT_Pista = 1;
                objumt.FK_IUM_CodUM = Convert.ToInt32(txtCodPista1.Text);
                objumt.FK_IT_CodTan = Convert.ToInt32(HFidTanda.Value);
                objumt.PK_IUMT_CodUsuModTan = txtCodPista1.Text + HFidTanda.Value;
                objctrtanda.registrarUMT(objumt);
                _log.CustomWriteOnLog("asignar tanda", "registra");
                string m = "Se registro Correctamente";
                Utils.AddScriptClientUpdatePanel(updPista1, "showMessage('top','center','" + m + "','success')");
            }
            catch (Exception ex)
            {

                _log.CustomWriteOnLog("asignar tanda", "Error : " + ex.Message + "Stac" + ex.StackTrace);
            }
        }

        protected void BtnPista2_Click(object sender, EventArgs e)
        {
            try
            {
                _log.CustomWriteOnLog("asignar tanda", "entra boton pista 2");
            }
            catch (Exception ex)
            {

                _log.CustomWriteOnLog("asignar tanda", "Error : " + ex.Message + "Stac" + ex.StackTrace);
            }
        }

        protected void BtnPista3_Click(object sender, EventArgs e)
        {
            try
            {
                _log.CustomWriteOnLog("asignar tanda", "entra boton pista 3");
            }
            catch (Exception ex)
            {

                _log.CustomWriteOnLog("asignar tanda", "Error : " + ex.Message + "Stac" + ex.StackTrace);
            }
        }

        protected void BtnPista4_Click(object sender, EventArgs e)
        {
            try
            {
                _log.CustomWriteOnLog("asignar tanda", "entra boton pista 4");
            }
            catch (Exception ex)
            {

                _log.CustomWriteOnLog("asignar tanda", "Error : " + ex.Message + "Stac" + ex.StackTrace);
            }
        }
    }
}