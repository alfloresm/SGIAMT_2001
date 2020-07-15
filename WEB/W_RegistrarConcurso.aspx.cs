using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;
using DTO;

namespace WEB
{
    public partial class W_RegistrarConcurso : System.Web.UI.Page
    {
        CtrConcurso objCtrConcurso = new CtrConcurso();
        DtoConcurso objDtoConcurso = new DtoConcurso();
        Log _log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["Id"] != null)
                {

                    txtPagina.InnerText = "Actualizar Concurso";
                    btnRegistrar.Text = "Actualizar";
                    Panel1.Visible = true;
                    Panel2.Visible = true;
                    obtenerConcurso(Request.Params["Id"]);

                }
                else
                {
                    txtPagina.InnerText = "Registrar Concurso";
                    btnRegistrar.Text = "Registrar";
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                }
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDateTime(txtFecha.Text) < DateTime.Now) {
                    string m = "fecha incorrecta";
                    Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m + "','danger')"); }
                else { 
                    if (Request.Params["Id"] != null)
                {
                    objDtoConcurso.PK_IC_IdConcurso = Convert.ToInt32(txtCodigo.Text);
                    objDtoConcurso.VC_NombreCon = txtNombre.Text;
                    objDtoConcurso.VC_LugarCon = txtlugar.Text;
                    objDtoConcurso.DTC_FechaConcurso = Convert.ToDateTime(txtFecha.Text);
                    objDtoConcurso.IC_CantidadSeriado = Convert.ToInt32(txtcantSeriado.Text);
                    objDtoConcurso.IC_CantidadNovel = Convert.ToInt32(txtcantNovel.Text);
                    objDtoConcurso.FK_IEC_IdEstado = Convert.ToInt32(ddlEstado.SelectedValue);
                    objCtrConcurso.ActualizarConcurso(objDtoConcurso);
                    string m = "Se actualizó correctamente";
                    _log.CustomWriteOnLog("regConcurso", m);
                    
                    Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m + "','success')");
                    //Response.Redirect("~/W_GestionarConcurso.aspx");
                }
                else
                {
                    objDtoConcurso.VC_NombreCon = txtNombre.Text;
                    objDtoConcurso.VC_LugarCon = txtlugar.Text;
                    objDtoConcurso.DTC_FechaConcurso = Convert.ToDateTime(txtFecha.Text);
                    objDtoConcurso.IC_CantidadSeriado = Convert.ToInt32(txtcantSeriado.Text);
                    objDtoConcurso.IC_CantidadNovel = Convert.ToInt32(txtcantNovel.Text);
                    objCtrConcurso.RegistrarConcurso(objDtoConcurso);
                    string m = "Se Registró correctamente";

                    Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m + "','success')");
                    //Response.Redirect("~/W_GestionarConcurso.aspx");
                }
                }
            }
            catch(Exception ex)
            {
                Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + ex.Message + "','danger')");
                
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "demo", "showNotification1('top','center','" + ex.Message + "','danger');", true);
            }
            
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/W_GestionarConcurso.aspx");
        }
        public void obtenerConcurso(string cod)
        {
            objDtoConcurso.PK_IC_IdConcurso = int.Parse(cod);
            objCtrConcurso.ObtenerConcurso(objDtoConcurso);

            txtCodigo.Text = objDtoConcurso.PK_IC_IdConcurso.ToString();
            txtNombre.Text = objDtoConcurso.VC_NombreCon.ToString();
            txtlugar.Text = objDtoConcurso.VC_LugarCon.ToString();
            txtFecha.Text = objDtoConcurso.DTC_FechaConcurso.ToString("yyyy-MM-dd");
            txtcantSeriado.Text = objDtoConcurso.IC_CantidadSeriado.ToString();
            txtcantNovel.Text = objDtoConcurso.IC_CantidadNovel.ToString();
            ddlEstado.SelectedIndex = objDtoConcurso.FK_IEC_IdEstado;
        }
    }
}