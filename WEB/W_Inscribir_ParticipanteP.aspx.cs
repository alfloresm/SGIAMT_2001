using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using CTR;
using System.Data;

namespace WEB
{
    public partial class W_Inscribirr_ParticipanteP : System.Web.UI.Page
    {
        CtrConcurso objCtrConcurso = new CtrConcurso();
        DtoUsuario objDtoUsuario = new DtoUsuario();
        CtrParticipante objCtrParticipante = new CtrParticipante();
        Log _log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                llenarConcursos();
                pnlParticipanteN.Visible = false;
                H1.InnerText = "S/.10";
                lblMensaje1.Text = "";
                lblmensaje2.Text = "";
            }

        }
        public void llenarConcursos()
        {
            DataSet ds = new DataSet();
            ds = objCtrConcurso.desplegableConcurso();
            ddlConcurso.DataSource = ds;
            ddlConcurso.DataTextField = "VC_NombreCon";
            ddlConcurso.DataValueField = "PK_IC_IdConcurso";
            ddlConcurso.DataBind();
            ddlConcurso.Items.Insert(0, new ListItem("Seleccione", "0"));
        }
        protected void RbSeriado_CheckedChanged(object sender, EventArgs e)
        {

            pnlParticipanteS.Visible = true;
            pnlParticipanteN.Visible = false;
            H1.InnerText = "S/.10";
            txtdni2.Text = "";
            txtCategoria2.Text = "";
            txtNombre2.Text = "";
        }

        protected void RbNovel_CheckedChanged(object sender, EventArgs e)
        {
            pnlParticipanteS.Visible = true;
            pnlParticipanteN.Visible = true;
            H1.InnerText = "S/.20";
        }

        protected void btnBuscar1_Click(object sender, EventArgs e)
        {
            try
            {
                objDtoUsuario.PK_IU_DNI = txtDni.Text;
                if (objCtrParticipante.existeUsuario(objDtoUsuario))
                {
                    if (objCtrParticipante.existeUsuarioAca(objDtoUsuario))
                    {
                        _log.CustomWriteOnLog("inscribir Participante", "entra boton");
                        DtoCategoria objcat = new DtoCategoria();
                        objCtrParticipante.obtenerParticipante(objDtoUsuario, objcat);
                        _log.CustomWriteOnLog("inscribir Participante","nombre"+ objDtoUsuario.nombres.ToString());
                        _log.CustomWriteOnLog("inscribir Participante", "categoria" + objcat.VCA_NomCategoria.ToString());
                        _log.CustomWriteOnLog("inscribir Participante", "genero" + objDtoUsuario.VU_Sexo.ToString());
                        txtNombre1.Text = objDtoUsuario.nombres.ToString();
                        txtCategoria.Text = objcat.VCA_NomCategoria.ToString();
                        txtGen.Text = objDtoUsuario.VU_Sexo.ToString();
                        updPanel1.Update();
                    }
                    else
                    {
                        string m = "Usuario no permitido";
                        Utils.AddScriptClientUpdatePanel(upnBotonBuscar1, "showMessage('top','center','" + m + "','danger')");
                    }
                }
                else
                {
                    string m = "No existe DNI";
                    Utils.AddScriptClientUpdatePanel(upnBotonBuscar1, "showMessage('top','center','" + m + "','danger')");
                }
            }
            catch(Exception ex)
            {
                _log.CustomWriteOnLog("inscribir Participante", "Error : " + ex.Message + "Stac" + ex.StackTrace);
            }
        }

        protected void btnBuscar2_Click(object sender, EventArgs e)
        {
            try
            {
                objDtoUsuario.PK_IU_DNI = txtdni2.Text;
                if (objCtrParticipante.existeUsuario(objDtoUsuario))
                {
                    if (objCtrParticipante.existeUsuarioAca(objDtoUsuario))
                    {
                        string gen = txtGen.Text;
                        if (objCtrParticipante.existeUsuarioGen(objDtoUsuario,gen))
                        {
                            _log.CustomWriteOnLog("inscribir Participante", "entra boton pareja");
                            DtoCategoria objcat = new DtoCategoria();
                            objCtrParticipante.obtenerParticipante(objDtoUsuario, objcat);
                            _log.CustomWriteOnLog("inscribir Participante", "*********************************");
                            _log.CustomWriteOnLog("inscribir Participante", "nombre" + objDtoUsuario.nombres.ToString());
                            _log.CustomWriteOnLog("inscribir Participante", "categoria" + objcat.VCA_NomCategoria.ToString());
                            _log.CustomWriteOnLog("inscribir Participante", "genero" + objDtoUsuario.VU_Sexo.ToString());
                            txtNombre2.Text = objDtoUsuario.nombres.ToString();
                            txtCategoria2.Text = objcat.VCA_NomCategoria;
                            updPanel2.Update();
                        }
                        else
                        {
                            string m = "Usuario no petenece a genero diferente";
                            Utils.AddScriptClientUpdatePanel(upnBotonBuscar2, "showMessage('top','center','" + m + "','danger')");
                        }
                    }
                    else
                    {
                        string m = "Usuario no permitido";
                        Utils.AddScriptClientUpdatePanel(upnBotonBuscar2, "showMessage('top','center','" + m + "','danger')");
                    }
                }
                else
                {
                    string m = "No existe DNI";
                    Utils.AddScriptClientUpdatePanel(upnBotonBuscar2, "showMessage('top','center','" + m + "','danger')");
                }
            }

            catch (Exception ex)
            {
                _log.CustomWriteOnLog("inscribir Participante", "Error : " + ex.Message + "Stac" + ex.StackTrace);
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnInscribir_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                _log.CustomWriteOnLog("inscribir Participante", "Error : " + ex.Message + "Stac" + ex.StackTrace);
            }
        }
    }
}