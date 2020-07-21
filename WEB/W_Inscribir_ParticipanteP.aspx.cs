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
        CtrUsuarioxModalidad objCtrUXM = new CtrUsuarioxModalidad();
        CtrInscripcion objCtrInscripcion = new CtrInscripcion();
        DtoUsuarioxModalidad objDtoUXM = new DtoUsuarioxModalidad();
        DtoInscripcion objDtoInscripcion = new DtoInscripcion();
        Log _log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                llenarConcursos();
                pnlParticipanteN.Visible = false;
                H1.InnerText = "S/.";
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
        protected void btnIr_Click(object sender, EventArgs e)
        {
            _log.CustomWriteOnLog("inscribir Participante", "ddlConcurso");
            DtoConcurso objCon = new DtoConcurso();
            objCon.PK_IC_IdConcurso = Convert.ToInt32(ddlConcurso.SelectedValue);
            _log.CustomWriteOnLog("inscribir Participante", "codConcurso: " + ddlConcurso.SelectedValue);
            objCtrConcurso.ObtenerConcurso(objCon);
            _log.CustomWriteOnLog("inscribir Participante", "precioSeriado: " + objCon.DC_PrecioSeriado.ToString());
            _log.CustomWriteOnLog("inscribir Participante", "precioNovel: " + objCon.DC_PrecioNovel.ToString());
            lblprecioS.Text = objCon.DC_PrecioSeriado.ToString();
            lblprecioN.Text = objCon.DC_PrecioNovel.ToString();
           
        }
        protected void RbSeriado_CheckedChanged(object sender, EventArgs e)
        {

            pnlParticipanteS.Visible = true;
            pnlParticipanteN.Visible = false;
            H1.InnerText = "S/."+lblprecioS.Text;
            txtdni2.Text = "";
            txtCategoria2.Text = "";
            txtNombre2.Text = "";
            txtCodCatN.Text = "";
            Uppago.Update();
        }

        protected void RbNovel_CheckedChanged(object sender, EventArgs e)
        {
            pnlParticipanteS.Visible = true;
            pnlParticipanteN.Visible = true;
            H1.InnerText = "S/."+lblprecioN.Text;
           
            Uppago.Update();
        }
        protected void RbAmbos_CheckedChanged(object sender, EventArgs e)
        {
            pnlParticipanteS.Visible = true;
            pnlParticipanteN.Visible = true;
            double sum = Convert.ToDouble(lblprecioS.Text) + Convert.ToDouble(lblprecioN.Text);
            H1.InnerText = "S/."+sum;
            Uppago.Update();
        }
        protected void RbParejaSeriado_CheckedChanged(object sender, EventArgs e)
        {

            _log.CustomWriteOnLog("inscribir Participante", "rbparejaseriado ");
            H1.InnerText = "";
            if (RbNovel.Checked) {
                double sum = Convert.ToDouble(lblprecioS.Text) + Convert.ToDouble(lblprecioN.Text);
                H1.InnerText = "S/." + sum;
                Uppago.Update();
            } else if (RbAmbos.Checked) {
                double sum = Convert.ToDouble(lblprecioS.Text) + Convert.ToDouble(lblprecioN.Text)+ Convert.ToDouble(lblprecioS.Text);
                H1.InnerText = "S/."+sum;
                Uppago.Update();
            }
            
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
                        txtcodCat.Text = objcat.PK_ICA_CodCat.ToString();
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
                            txtCodCatN.Text = objcat.PK_ICA_CodCat.ToString();
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

        protected void btnInscribir_Click(object sender, EventArgs e)
        {
            try
            {
                int Cat1 = Convert.ToInt32(txtcodCat.Text);
                
                objDtoUXM.FK_VU_Dni = txtDni.Text;
                if (RbSeriado.Checked)
                {
                    if (objCtrUXM.existeUXM_S(objDtoUXM)==false)
                    {
                        objDtoUXM.FK_IM_IdModalidad = 1;
                        objDtoUXM.FK_IC_IdConcurso = Convert.ToInt32(ddlConcurso.SelectedValue);
                        objCtrUXM.registrarUXM_S(objDtoUXM);
                        _log.CustomWriteOnLog("inscribir Participante", "id UXM: " + objDtoUXM.PK_IUM_CodUM.ToString());
                        objDtoInscripcion.FK_IUM_CodUm = objDtoUXM.PK_IUM_CodUM;
                        objDtoInscripcion.DI_Monto = Convert.ToDouble(lblprecioS.Text);
                        objCtrInscripcion.RegistrarInscripcionP(objDtoInscripcion);
                        string m = "Se registró la inscripción";
                        Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m + "','success')");
                    }
                    else
                    {
                        string m = "Existe Registro";
                        Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m + "','danger')");
                    }
                }else if (RbNovel.Checked && cbParticipa.Checked) {
                    int Cat2 = Convert.ToInt32(txtCodCatN.Text);
                    if (Cat1-Cat2==-1|| Cat1 - Cat2 == 0 || Cat1 - Cat2 == 1)
                {
                        objDtoUXM.FK_DNI_Pareja = txtdni2.Text;
                        if (!objCtrUXM.existeUXM_N(objDtoUXM))
                        {

                        }
                        else
                        {
                            string m = "Existe Registro";
                            Utils.AddScriptClientUpdatePanel(upnBotonBuscar2, "showMessage('top','center','" + m + "','danger')");
                        }
                    }
                else
                {
                    string m = "No puede inscribirse con pareja mayor a una categoria";
                    Utils.AddScriptClientUpdatePanel(upnBotonBuscar2, "showMessage('top','center','" + m + "','danger')");
                }
                }else if (RbNovel.Checked)
                {
                    int Cat2 = Convert.ToInt32(txtCodCatN.Text);
                    if (Cat1 - Cat2 == -1 || Cat1 - Cat2 == 0 || Cat1 - Cat2 == 1)
                    {
                        objDtoUXM.FK_DNI_Pareja = txtdni2.Text;
                        if (!objCtrUXM.existeUXM_N(objDtoUXM))
                        {

                        }
                        else
                        {
                            string m = "Existe Registro";
                            Utils.AddScriptClientUpdatePanel(upnBotonBuscar2, "showMessage('top','center','" + m + "','danger')");
                        }
                    }
                    else
                    {
                        string m = "No puede inscribirse con pareja mayor a una categoria";
                        Utils.AddScriptClientUpdatePanel(upnBotonBuscar2, "showMessage('top','center','" + m + "','danger')");
                    }
                }
                else if(RbAmbos.Checked && cbParticipa.Checked)
                {
                    DtoUsuarioxModalidad objdtoUXM2 = new DtoUsuarioxModalidad();
                    objdtoUXM2.FK_VU_Dni = txtdni2.Text;
                    int Cat2 = Convert.ToInt32(txtCodCatN.Text);
                    if (Cat1 - Cat2 == -1 || Cat1 - Cat2 == 0 || Cat1 - Cat2 == 1)
                    {
                        if (!objCtrUXM.existeUXM_S(objDtoUXM) && !objCtrUXM.existeUXM_S(objdtoUXM2))
                        {

                            //registra primero seriados
                            objDtoUXM.FK_DNI_Pareja = txtdni2.Text;
                            if (!objCtrUXM.existeUXM_N(objDtoUXM))
                            {

                            }
                            else
                            {
                                string m = "Existe Registro";
                                Utils.AddScriptClientUpdatePanel(upnBotonBuscar2, "showMessage('top','center','" + m + "','danger')");
                            }
                        }
                        else
                        {
                            string m = "Existe Registro";
                            Utils.AddScriptClientUpdatePanel(upnBotonBuscar2, "showMessage('top','center','" + m + "','danger')");
                        }
                        
                    }
                    else
                    {
                        string m = "No puede inscribirse con pareja mayor a una categoria";
                        Utils.AddScriptClientUpdatePanel(upnBotonBuscar2, "showMessage('top','center','" + m + "','danger')");
                    }
                }
                else if (RbAmbos.Checked)
                {
                    int Cat2 = Convert.ToInt32(txtCodCatN.Text);
                    if (Cat1 - Cat2 == -1 || Cat1 - Cat2 == 0 || Cat1 - Cat2 == 1)
                    {
                        if (!objCtrUXM.existeUXM_S(objDtoUXM))
                        {
                            //registra primero seriado
                            objDtoUXM.FK_DNI_Pareja = txtdni2.Text;
                            if (!objCtrUXM.existeUXM_N(objDtoUXM))
                            {

                            }
                            else
                            {
                                string m = "Existe Registro";
                                Utils.AddScriptClientUpdatePanel(upnBotonBuscar2, "showMessage('top','center','" + m + "','danger')");
                            }
                        }
                        else
                        {
                            string m = "Existe Registro";
                            Utils.AddScriptClientUpdatePanel(upnBotonBuscar2, "showMessage('top','center','" + m + "','danger')");
                        }
                    }
                    else
                    {
                        string m = "No puede inscribirse con pareja mayor a una categoria";
                        Utils.AddScriptClientUpdatePanel(upnBotonBuscar2, "showMessage('top','center','" + m + "','danger')");
                    }
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

    }
}