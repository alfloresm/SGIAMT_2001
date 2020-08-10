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
using System.Text;

namespace WEB
{
    public partial class W_Calificar_Participante : System.Web.UI.Page
    {
        CtrPuntaje objctrpuntaje = new CtrPuntaje();
        CtrTanda objctrTanda = new CtrTanda();
        DtoPuntaje objdtopuntaje = new DtoPuntaje();
        DtoTanda objdtotanda = new DtoTanda();
        DtoUsuarioModalidadTanda objdtoUMT = new DtoUsuarioModalidadTanda();
        Log _log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                _log.CustomWriteOnLog("calificar Participante", "Carga Página");
                try
                {
                    if (Session["ApellidoM"] != null)
                    {

                        string numJ = Session["ApellidoM"].ToString();
                    }
                    else
                    {
                        Response.Redirect("Login_.aspx");
                    }
                    
                }
                catch (Exception ex)
                {
                    _log.CustomWriteOnLog("calificar Participante", "Error : " + ex.Message + "Stac" + ex.StackTrace);
                }
            }
        }
        
        protected void btnBuscar1_Click(object sender, EventArgs e)
        {
            try { 
                objdtotanda.PK_IT_CodTan = Convert.ToInt32(txtTanda.Text);
                objdtoUMT.FK_IT_CodTan = Convert.ToInt32(txtTanda.Text);
                if (objctrTanda.selectTanda(objdtotanda))
                {
                    _log.CustomWriteOnLog("calificar Participante", "entra boton");
                    objctrTanda.obtenerTanda(objdtotanda);
                    _log.CustomWriteOnLog("calificar Participante", "categoria: "+ objdtotanda.VT_Descripcion);

                    lblCategoria.Text = objdtotanda.VT_Descripcion;
                    _log.CustomWriteOnLog("calificar Participante", "categoria: "+ objdtotanda.VT_TipoTanda.ToString());
                    if (objdtotanda.VT_TipoTanda == 1)
                    {
                        lblModalidad.Text = "SERIADO";
                    }
                    else if (objdtotanda.VT_TipoTanda == 2)
                    {
                        lblModalidad.Text = "NOVEL";
                    }
                    UpdatePanelInfo.Update();
                    //--------------------------OBTENER PARTICIPANTES-----------------------
                    CtrTanda ctrT = new CtrTanda();
                    DataTable dt = new DataTable();
                    dt = ctrT.obtenerParticipantesxTanda(objdtoUMT);
                    int cont = 0;
                    StringBuilder cardParticipante = new StringBuilder();
                    foreach (DataRow row in dt.Rows)
                    {
                        objdtoUMT.FK_IUM_CodUM = Convert.ToInt32(row["FK_IUM_CodUM"].ToString());
                        _log.CustomWriteOnLog("calificar Participante", "participante: "+ row["FK_IUM_CodUM"].ToString());
                        objdtoUMT.IUMT_Pista = Convert.ToInt32(row["IUMT_Pista"].ToString());
                        _log.CustomWriteOnLog("calificar Participante", "pista: " + row["IUMT_Pista"].ToString());
                        _log.CustomWriteOnLog("calificar Participante", "pista: " + row["PK_IUMT_CodUsuModTan"].ToString());
                        objdtoUMT.PK_IUMT_CodUsuModTan = row["PK_IUMT_CodUsuModTan"].ToString();
                        cont = cont + 1;
                        _log.CustomWriteOnLog("calificar Participante", "contador: "+cont);
                        cardParticipante.Append("<div class='col-md-6'>");
                        cardParticipante.Append("<div class='card'>");
                        cardParticipante.Append("<div class='card-header card-header-text' data-background-color='black'>");
                        cardParticipante.Append("<h4 id = 'H1' runat='server' class='card-title'>Pista N°"+ objdtoUMT.IUMT_Pista + "</h4>");
                        cardParticipante.Append("<label id = 'COD' runat='server' class='card-title' hidden>" + objdtoUMT.PK_IUMT_CodUsuModTan.ToString()+ "</label>");
                        cardParticipante.Append("</div>");
                        cardParticipante.Append("<div class='card-content'>");
                        cardParticipante.Append("<div class='col-md-6 col-md-offset-3'>");
                        cardParticipante.Append("<h4 class='text-center text-uppercase'>#Codigo Participante: </h4>");
                        cardParticipante.Append("<h3 class='text-center'>"+ objdtoUMT.FK_IUM_CodUM.ToString() + "</h3>");
                        cardParticipante.Append("<br/>");
                        cardParticipante.Append("</div>");
                        cardParticipante.Append("<div class='col-md-12'>");
                        cardParticipante.Append("<div class='col-md-4 text-center'>");
                        cardParticipante.Append("<button id ='btn1' class='btn btn-danger' onclick='CambiarTextboxHF(3," + objdtoUMT.FK_IUM_CodUM.ToString() +")'>3</button>");
                        cardParticipante.Append("</div>");
                        cardParticipante.Append("<div class='col-md-4 text-center'>");
                        cardParticipante.Append("<button id ='btn2' class='btn btn-warning' onclick='CambiarTextboxHF(4," + objdtoUMT.FK_IUM_CodUM.ToString() +")'>4</button>");
                        cardParticipante.Append("</div>");
                        cardParticipante.Append("<div class='col-md-4 text-center'>");
                        cardParticipante.Append("<button id ='btn3' class='btn btn-success' onclick='CambiarTextboxHF(5," + objdtoUMT.FK_IUM_CodUM.ToString() +")'>5</button>");
                        cardParticipante.Append("</div>");
                        cardParticipante.Append("</div>");
                        cardParticipante.Append("</div>");
                        cardParticipante.Append("</div>");
                        cardParticipante.Append("</div>");
                        _log.CustomWriteOnLog("calificar Participante", "------------------- ");
                    }
                    
                    LiteralParticipantes.Text = cardParticipante.ToString();
                    UpdatePanelParticipantes.Update();
                }
                else
                {
                    txtTanda.Text = "";
                    string m = "No existe Tanda";
                    Utils.AddScriptClientUpdatePanel(upnBotonBuscar1, "showMessage('top','center','" + m + "','danger')");
                }
            }
            catch(Exception ex)
            {
                _log.CustomWriteOnLog("calificar Participante", "Error : " + ex.Message + "Stac" + ex.StackTrace);
            }
        }

        protected void hfParticipante_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                string numJ = Session["ApellidoM"].ToString();
                _log.CustomWriteOnLog("calificar Participante", "jurado es: " + numJ);
                objdtopuntaje.IP_Puntaje = int.Parse(hfBoton.Value);
                _log.CustomWriteOnLog("calificar Participante", "puntaje es: " + hfBoton.Value);
                objdtopuntaje.FK_IUMT_UsuModTan = hfParticipante.Value + txtTanda.Text;
                _log.CustomWriteOnLog("calificar Participante", "participante es: " + hfParticipante.Value + txtTanda.Text);
                objdtopuntaje.IP_NumeroJurado = int.Parse(numJ);
                _log.CustomWriteOnLog("calificar Participante", "jurado es: " + numJ);
                if (objctrpuntaje.existePuntaje(objdtopuntaje))
                {
                    objctrpuntaje.ActualizarPuntaje(objdtopuntaje);
                    _log.CustomWriteOnLog("calificar Participante", "se Actualizó puntaje");
                }
                else
                {
                    DtoUsuarioModalidadTanda objUTM = new DtoUsuarioModalidadTanda();
                    objUTM.PK_IUMT_CodUsuModTan = hfParticipante.Value + txtTanda.Text;
                    CtrTanda objctr = new CtrTanda();
                    objctrpuntaje.RegistrarPuntaje(objdtopuntaje);
                    objctr.actualizarEstadoUMT(objUTM);
                  _log.CustomWriteOnLog("calificar Participante", "se registró puntaje");
                }
                
                hfBoton.Value = "";
                hfParticipante.Value = "";
            }
            catch(Exception ex)
            {
                _log.CustomWriteOnLog("calificar Participante", "Error : " + ex.Message + "Stac" + ex.StackTrace);
            }
        }
    }
}