using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;
using System.Data;
using System.Data.SqlClient;

namespace WEB
{
    public partial class W_Buscar_Tanda : System.Web.UI.Page
    {
        Log _log = new Log();
        CtrTanda objctrTanda = new CtrTanda();
        DtoTanda objdtotanda = new DtoTanda();
        DtoUsuarioModalidadTanda objdtoUMT = new DtoUsuarioModalidadTanda();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                _log.CustomWriteOnLog("mostrar resultado", "Carga Página");
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
                    _log.CustomWriteOnLog("mostrar resultado", "Error : " + ex.Message + "Stac" + ex.StackTrace);
                }
            }
        }

        protected void btnBuscar1_Click(object sender, EventArgs e)
        {
            try
            {
                objdtotanda.PK_IT_CodTan = Convert.ToInt32(txtTanda.Text);
                if (objctrTanda.selectTanda(objdtotanda))
                {
                    if (validacionCalificado())
                    {
                        objdtotanda.PK_IT_CodTan = Convert.ToInt32(txtTanda.Text);
                        _log.CustomWriteOnLog("mostrar resultado", "entra boton");
                        CtrTanda CTRT = new CtrTanda();
                        CTRT.obtenerTanda(objdtotanda);
                        if (objdtotanda.VT_Estado == "NO CALIFICADO")
                        {
                            //info de tanda
                            _log.CustomWriteOnLog("mostrar resultado", "categoria: " + objdtotanda.VT_Descripcion);

                            lblCategoria.Text = objdtotanda.VT_Descripcion;
                            _log.CustomWriteOnLog("mostrar resultado", "categoria: " + objdtotanda.VT_TipoTanda.ToString());
                            if (objdtotanda.VT_TipoTanda == 1)
                            {
                                lblModalidad.Text = "SERIADO";
                            }
                            else if (objdtotanda.VT_TipoTanda == 2)
                            {
                                lblModalidad.Text = "NOVEL";
                            }
                            UpdatePanelInfo.Update();
                            //SUMA PUNTAJES y actualiza puntaje total

                            CtrTanda ctrT = new CtrTanda();
                            DataTable dt = new DataTable();
                            objdtoUMT.FK_IT_CodTan = Convert.ToInt32(txtTanda.Text);
                            dt = ctrT.obtenerParticipantesxTanda(objdtoUMT);
                            foreach (DataRow row in dt.Rows)
                            {
                                
                                objdtoUMT.PK_IUMT_CodUsuModTan = row["PK_IUMT_CodUsuModTan"].ToString();
                                _log.CustomWriteOnLog("mostrar resultado", "codigo: " + row["PK_IUMT_CodUsuModTan"].ToString());
                                objdtoUMT.IUMT_PuntajeTotal = ctrT.sumaPuntajes(objdtoUMT);
                                ctrT.actualizarPuntajeT(objdtoUMT);
                                _log.CustomWriteOnLog("mostrar resultado", "SE ACTUALIZO EL PUNTAJE");
                            }
                            //actualiza estado a CALIFICADO
                            ctrT.actualizarEstadoT(objdtotanda);

                            //TABLA CALIFICADOS
                            CtrTanda ctr = new CtrTanda();
                            GVCalificacion.DataSource = ctr.listar_calificados_S(objdtotanda);
                            GVCalificacion.DataBind();


                            DataTable dtC = ctr.listar_calificados_S(objdtotanda);
                            DataRow rowC = dtC.Rows[0];

                            codGanador.InnerText = "N° " + rowC["FK_IUM_CodUM"].ToString();
                            nombre.InnerText = rowC["Nombres"].ToString();
                            objdtotanda.IT_Ganador = Convert.ToInt32(rowC["FK_IUM_CodUM"].ToString());
                            //actualiza ganador
                            ctr.actualizarganadorT(objdtotanda);

                            UpdatePanelCalificacion.Update();

                        }
                        else
                        {
                            //info de tanda
                            _log.CustomWriteOnLog("mostrar resultado", "categoria: " + objdtotanda.VT_Descripcion);

                            lblCategoria.Text = objdtotanda.VT_Descripcion;
                            _log.CustomWriteOnLog("mostrar resultado", "categoria: " + objdtotanda.VT_TipoTanda.ToString());
                            if (objdtotanda.VT_TipoTanda == 1)
                            {
                                lblModalidad.Text = "SERIADO";
                            }
                            else if (objdtotanda.VT_TipoTanda == 2)
                            {
                                lblModalidad.Text = "NOVEL";
                            }
                            UpdatePanelInfo.Update();
                            //TABLA CALIFICADOS
                            CtrTanda ctr = new CtrTanda();
                            GVCalificacion.DataSource = ctr.listar_calificados_S(objdtotanda);
                            GVCalificacion.DataBind();

                            
                            DataTable dt = ctr.listar_calificados_S(objdtotanda);
                            DataRow row = dt.Rows[0];

                            codGanador.InnerText = "N° " + row["FK_IUM_CodUM"].ToString();

                            nombre.InnerText = row["Nombres"].ToString();

                            UpdatePanelCalificacion.Update();
                        }
                    }
                    else
                    {
                        txtTanda.Text = "";
                        string m = "Falta terminar de calificar tanda";
                        Utils.AddScriptClientUpdatePanel(upnBotonBuscar1, "showMessage('top','center','" + m + "','danger')");
                    }
                }
                else
                {
                    txtTanda.Text = "";
                    string m = "No existe Tanda";
                    Utils.AddScriptClientUpdatePanel(upnBotonBuscar1, "showMessage('top','center','" + m + "','danger')");
                }
            }
            catch (Exception ex)
            {

                _log.CustomWriteOnLog("mostrar resultado", "Error : " + ex.Message + "Stac" + ex.StackTrace);
            }
        }
        public bool validacionCalificado()
        {
            try
            {
                objdtotanda.PK_IT_CodTan = Convert.ToInt32(txtTanda.Text);
                _log.CustomWriteOnLog("mostrar resultado", "entra validacion");
                objctrTanda.obtenerTandaP(objdtotanda);
                objdtoUMT.FK_IT_CodTan= Convert.ToInt32(txtTanda.Text);
                CtrTanda ctrT = new CtrTanda();
                DataTable dt = new DataTable();
                dt = ctrT.obtenerParticipantesxTanda(objdtoUMT);
                if (objdtotanda.VT_TipoTanda == 1)
                {
                    //SERIADO
                    int valor = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        objdtoUMT.FK_IUM_CodUM = Convert.ToInt32(row["FK_IUM_CodUM"].ToString());
                        objdtoUMT.IUMT_Estado = Convert.ToInt32(row["IUMT_Estado"].ToString());
                        if (objdtoUMT.IUMT_Estado == 3)
                        {
                            valor++;
                        }
                        else
                        {
                            valor = valor + 0;
                        }
                        _log.CustomWriteOnLog("mostrar resultado", "valor=" + valor.ToString());
                    }
                    int cfilas = dt.Rows.Count;
                    if (cfilas == valor)
                    {
                        _log.CustomWriteOnLog("mostrar resultado", "VALIDACION TRUE");
                        return true;
                    }
                    else
                    {
                        _log.CustomWriteOnLog("mostrar resultado", "VALIDACION FALSE");
                        return false;
                    }

                }
                else if (objdtotanda.VT_TipoTanda == 2)
                {
                    //NOVEL
                    int valor = 0;
                    int cfilas = dt.Rows.Count;
                    foreach (DataRow row in dt.Rows)
                    {
                        objdtoUMT.FK_IUM_CodUM = Convert.ToInt32(row["FK_IUM_CodUM"].ToString());
                        objdtoUMT.IUMT_Estado = Convert.ToInt32(row["IUMT_Estado"].ToString());
                        if (objdtoUMT.IUMT_Estado == 6)
                        {
                            valor++;
                        }
                        else
                        {
                            valor = valor + 0;
                        }
                    }
                    if (cfilas == valor)
                    {
                        _log.CustomWriteOnLog("mostrar resultado", "VALIDACION TRUE");
                        return true;
                    }
                    else
                    {
                        _log.CustomWriteOnLog("mostrar resultado", "VALIDACION FALSE");
                        return false;
                    }
                }
                else
                {
                    _log.CustomWriteOnLog("mostrar resultado", "VALIDACION ninguna");
                    return false;
                }

            }
            catch (Exception ex)
            {

                _log.CustomWriteOnLog("mostrar resultado", "Error : " + ex.Message + "Stac" + ex.StackTrace);
                return false;
            }
        }
    }
}