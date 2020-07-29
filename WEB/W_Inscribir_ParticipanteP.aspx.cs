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
        CtrUsuario objCtrUsuario = new CtrUsuario();
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
        protected void rbSi_CheckedChanged(object sender, EventArgs e)
        {
            _log.CustomWriteOnLog("inscribir Participante", "rbparejaseriado ");
            H1.InnerText = "";
            if (RbNovel.Checked)
            {
                double sum = Convert.ToDouble(lblprecioS.Text) + Convert.ToDouble(lblprecioN.Text);
                H1.InnerText = "S/." + sum;
                Uppago.Update();
            }
            else if (RbAmbos.Checked)
            {
                double sum = Convert.ToDouble(lblprecioS.Text) + Convert.ToDouble(lblprecioN.Text) + Convert.ToDouble(lblprecioS.Text);
                H1.InnerText = "S/." + sum;
                Uppago.Update();
            }
        }
        protected void rbNo_CheckedChanged(object sender, EventArgs e)
        {
            _log.CustomWriteOnLog("inscribir Participante", "rbparejaseriado ");
            H1.InnerText = "";
            if (RbNovel.Checked)
            {
                double sum = Convert.ToDouble(lblprecioN.Text);
                H1.InnerText = "S/." + sum;
                Uppago.Update();
            }
            else if (RbAmbos.Checked)
            {
                double sum = Convert.ToDouble(lblprecioN.Text) + Convert.ToDouble(lblprecioS.Text);
                H1.InnerText = "S/." + sum;
                Uppago.Update();
            }
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
                DtoUsuarioxModalidad objdtouxm2 = new DtoUsuarioxModalidad();
                int Cat1 = Convert.ToInt32(txtcodCat.Text);
                
                objDtoUXM.FK_VU_Dni = txtDni.Text;
                objdtouxm2.FK_VU_Dni = txtdni2.Text;
                objDtoUXM.FK_IC_IdConcurso = Convert.ToInt32(ddlConcurso.SelectedValue);
                objdtouxm2.FK_IC_IdConcurso = Convert.ToInt32(ddlConcurso.SelectedValue);
                if (RbSeriado.Checked)
                {
                   
                    if (objCtrUXM.existeUXM_S(objDtoUXM)==false)
                    {
                        objDtoUXM.FK_IM_IdModalidad = 1;
                        objCtrUXM.registrarUXM_S(objDtoUXM);
                        _log.CustomWriteOnLog("inscribir Participante", "id UXM: " + objDtoUXM.PK_IUM_CodUM.ToString());
                        objDtoInscripcion.FK_IUM_CodUm = objDtoUXM.PK_IUM_CodUM;
                        objDtoInscripcion.DI_Monto = Convert.ToDouble(lblprecioS.Text);
                        objCtrInscripcion.RegistrarInscripcionP(objDtoInscripcion);
                        objCtrUsuario.EnviarCorreoInscripcion(objDtoUXM);
                        string m = "Se registró la inscripción";
                        Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m + "','success')");
                    }
                    else
                    {
                        string m = "Existe Registro";
                        Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m + "','danger')");
                    }
                }else if (RbNovel.Checked && rbSi.Checked) {
                    int Cat2 = Convert.ToInt32(txtCodCatN.Text);
                    double sum = Convert.ToDouble(lblprecioS.Text) + Convert.ToDouble(lblprecioN.Text);
                    H1.InnerText = "S/." + sum;
                    Uppago.Update();
                    if (Cat1-Cat2==-1|| Cat1 - Cat2 == 0 || Cat1 - Cat2 == 1)
                {
                        objDtoUXM.FK_DNI_Pareja = txtdni2.Text;
                               
                        if (!objCtrUXM.existeUXM_S(objdtouxm2))
                        {
                            //1° registra seriado
                            objdtouxm2.FK_IM_IdModalidad = 1;
                            objCtrUXM.registrarUXM_S(objdtouxm2);
                            _log.CustomWriteOnLog("inscribir Participante", "id UXM pareja seriado: " + objdtouxm2.PK_IUM_CodUM.ToString());
                            objDtoInscripcion.FK_IUM_CodUm = objdtouxm2.PK_IUM_CodUM;
                            objDtoInscripcion.DI_Monto = Convert.ToDouble(lblprecioS.Text);
                            objCtrInscripcion.RegistrarInscripcionP(objDtoInscripcion);
                            objCtrUsuario.EnviarCorreoInscripcion(objdtouxm2);
                            string m = "Se registró la inscripción de pareja seriado";
                            Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m + "','success')");

                            if (!objCtrUXM.existeUXM_N(objDtoUXM)) { 
                            //2° inscribir novel
                                objDtoUXM.FK_IM_IdModalidad = 2;
                                objCtrUXM.registrarUXM_N(objDtoUXM);
                                _log.CustomWriteOnLog("inscribir Participante", "NOVEL id UXM: " + objDtoUXM.PK_IUM_CodUM.ToString());
                                objDtoInscripcion.FK_IUM_CodUm = objDtoUXM.PK_IUM_CodUM;
                                objDtoInscripcion.DI_Monto = Convert.ToDouble(lblprecioN.Text);
                                objCtrInscripcion.RegistrarInscripcionP(objDtoInscripcion);
                                objCtrUsuario.EnviarCorreoInscripcion(objDtoUXM);
                                string m1 = "Se registró la inscripción";
                                Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m1 + "','success')");
                            }
                            else
                            {
                                string m2 = "Existe Registro de novel";
                                Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m2 + "','danger')");
                            }
                        }
                        else
                        {
                            string m = "Existe Registro de pareja seriado";
                            Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m + "','danger')");
                        }
                    }
                else
                {
                    string m = "No puede inscribirse con pareja mayor a una categoria";
                    Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m + "','danger')");
                }
                }else if (RbNovel.Checked)
                {
                    int Cat2 = Convert.ToInt32(txtCodCatN.Text);
                    if (Cat1 - Cat2 == -1 || Cat1 - Cat2 == 0 || Cat1 - Cat2 == 1)
                    {
                        objDtoUXM.FK_DNI_Pareja = txtdni2.Text;
                        objDtoUXM.FK_IC_IdConcurso=Convert.ToInt32(ddlConcurso.SelectedValue);
                        if (!objCtrUXM.existeUXM_N(objDtoUXM))
                        {
                            objDtoUXM.FK_IM_IdModalidad = 2;
                            objCtrUXM.registrarUXM_N(objDtoUXM);
                            _log.CustomWriteOnLog("inscribir Participante", "Novel id UXM: " + objDtoUXM.PK_IUM_CodUM.ToString());
                            objDtoInscripcion.FK_IUM_CodUm = objDtoUXM.PK_IUM_CodUM;
                            objDtoInscripcion.DI_Monto = Convert.ToDouble(lblprecioN.Text);
                            objCtrInscripcion.RegistrarInscripcionP(objDtoInscripcion);
                            objCtrUsuario.EnviarCorreoInscripcion(objDtoUXM);
                            string m = "Se registró la inscripción de novel";
                            Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m + "','success')");
                        }
                        else
                        {
                            string m = "Existe Registro";
                            Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m + "','danger')");
                        }
                    }
                    else
                    {
                        string m = "No puede inscribirse con pareja mayor a una categoria";
                        Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m + "','danger')");
                    }
                }
                else if(RbAmbos.Checked && rbSi.Checked)
                {
                    double sum = Convert.ToDouble(lblprecioS.Text) + Convert.ToDouble(lblprecioN.Text) + Convert.ToDouble(lblprecioS.Text);
                    H1.InnerText = "S/." + sum;
                    Uppago.Update();
                    int Cat2 = Convert.ToInt32(txtCodCatN.Text);
                    if (Cat1 - Cat2 == -1 || Cat1 - Cat2 == 0 || Cat1 - Cat2 == 1)
                    {
                        if (!objCtrUXM.existeUXM_S(objDtoUXM) && !objCtrUXM.existeUXM_S(objdtouxm2))
                        {
                            //registra primero seriados
                            //1° registro seriado
                            objDtoUXM.FK_IM_IdModalidad = 1;
                            objCtrUXM.registrarUXM_S(objDtoUXM);
                            _log.CustomWriteOnLog("inscribir Participante", "1° seriado id UXM: " + objDtoUXM.PK_IUM_CodUM.ToString());
                            objDtoInscripcion.FK_IUM_CodUm = objDtoUXM.PK_IUM_CodUM;
                            objDtoInscripcion.DI_Monto = Convert.ToDouble(lblprecioS.Text);
                            objCtrInscripcion.RegistrarInscripcionP(objDtoInscripcion);
                            objCtrUsuario.EnviarCorreoInscripcion(objDtoUXM);
                            string m = "Se registró la inscripción 1° seriado";
                            Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m + "','success')");
                            //2° registro seriado
                            objdtouxm2.FK_IM_IdModalidad = 1;
                            objCtrUXM.registrarUXM_S(objdtouxm2);
                            _log.CustomWriteOnLog("inscribir Participante", "1° seriado id UXM: " + objDtoUXM.PK_IUM_CodUM.ToString());
                            objDtoInscripcion.FK_IUM_CodUm = objdtouxm2.PK_IUM_CodUM;
                            objDtoInscripcion.DI_Monto = Convert.ToDouble(lblprecioS.Text);
                            objCtrInscripcion.RegistrarInscripcionP(objDtoInscripcion);
                            objCtrUsuario.EnviarCorreoInscripcion(objDtoUXM);
                            string m1 = "Se registró la inscripción 2° seriado";
                            Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m1 + "','success')");
                            //registra segundo novel
                            objDtoUXM.FK_DNI_Pareja = txtdni2.Text;
                            if (!objCtrUXM.existeUXM_N(objDtoUXM))
                            {
                                objDtoUXM.FK_IM_IdModalidad = 2;
                                objCtrUXM.registrarUXM_N(objDtoUXM);
                                _log.CustomWriteOnLog("inscribir Participante", "**AMBOS: id UXM novel: " + objDtoUXM.PK_IUM_CodUM.ToString());
                                objDtoInscripcion.FK_IUM_CodUm = objDtoUXM.PK_IUM_CodUM;
                                objDtoInscripcion.DI_Monto = Convert.ToDouble(lblprecioN.Text);
                                objCtrInscripcion.RegistrarInscripcionP(objDtoInscripcion);
                                objCtrUsuario.EnviarCorreoInscripcion(objDtoUXM);
                                string m2 = "Se registró la inscripción novel";
                                Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m2 + "','success')");
                            }
                            else
                            {
                                string m3 = "Existe Registro novel";
                                Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m3 + "','danger')");
                            }
                        }
                        else
                        {
                            string m = "Existe Registro en seriado";
                            Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m + "','danger')");
                        }
                        
                    }
                    else
                    {
                        string m = "No puede inscribirse con pareja mayor a una categoria";
                        Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m + "','danger')");
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
                            objDtoUXM.FK_IM_IdModalidad = 1;
                            objCtrUXM.registrarUXM_S(objDtoUXM);
                            _log.CustomWriteOnLog("inscribir Participante", "**AMBOS: id UXM seriado: " + objDtoUXM.PK_IUM_CodUM.ToString());
                            objDtoInscripcion.FK_IUM_CodUm = objDtoUXM.PK_IUM_CodUM;
                            objDtoInscripcion.DI_Monto = Convert.ToDouble(lblprecioS.Text);
                            objCtrInscripcion.RegistrarInscripcionP(objDtoInscripcion);
                            objCtrUsuario.EnviarCorreoInscripcion(objDtoUXM);
                            string m = "Se registró la inscripción seriado";
                            Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m + "','success')");
                            
                            objDtoUXM.FK_DNI_Pareja = txtdni2.Text;

                            if (!objCtrUXM.existeUXM_N(objDtoUXM))
                            {
                                objDtoUXM.FK_IM_IdModalidad = 2;
                                objCtrUXM.registrarUXM_N(objDtoUXM);
                                _log.CustomWriteOnLog("inscribir Participante", "**AMBOS: id UXM novel: " + objDtoUXM.PK_IUM_CodUM.ToString());
                                objDtoInscripcion.FK_IUM_CodUm = objDtoUXM.PK_IUM_CodUM;
                                objDtoInscripcion.DI_Monto = Convert.ToDouble(lblprecioN.Text);
                                objCtrInscripcion.RegistrarInscripcionP(objDtoInscripcion);
                                objCtrUsuario.EnviarCorreoInscripcion(objDtoUXM);
                                string m1 = "Se registró la inscripción novel";
                                Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m1+ "','success')");
                            }
                            else
                            {
                                string m2 = "Existe Registro en novel";
                                Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m2 + "','danger')");
                            }
                        }
                        else
                        {
                            string m = "Existe Registro seriado";
                            Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m + "','danger')");
                        }
                    }
                    else
                    {
                        string m = "No puede inscribirse con pareja mayor a una categoria";
                        Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m + "','danger')");
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
        public void inscribir(DtoUsuarioxModalidad objDtoUXM, DtoInscripcion objDtoInscripcion, int m)
        {
            _log.CustomWriteOnLog("inscribir Participante", "****entro metodo inscribir");
            objDtoUXM.FK_IM_IdModalidad = m;
            objCtrUXM.registrarUXM_N(objDtoUXM);
            _log.CustomWriteOnLog("inscribir Participante", "**metodo inscribir pk uxm" + objDtoUXM.PK_IUM_CodUM.ToString());
            
            objDtoInscripcion.FK_IUM_CodUm = objDtoUXM.PK_IUM_CodUM;
            if (m == 1) { 
                objDtoInscripcion.DI_Monto = Convert.ToDouble(lblprecioS.Text);}
            else if (m == 2)
            {
                objDtoInscripcion.DI_Monto = Convert.ToDouble(lblprecioN.Text);
            }
            objCtrInscripcion.RegistrarInscripcionP(objDtoInscripcion);
        }
        public void limpiar()
        {
            ddlConcurso.SelectedValue="0";
            pnlParticipanteN.Visible = false;
            H1.InnerText = "S/.";
            lblMensaje1.Text = "";
            lblmensaje2.Text = "";
            txtCategoria.Text = "";
            txtCategoria2.Text = "";
            txtcodCat.Text = "";
            txtCodCatN.Text = "";
            txtDni.Text = "";
            txtdni2.Text = "";
            txtGen.Text = "";
            txtNombre1.Text = "";
            txtNombre2.Text = "";
            RbSeriado.Checked = false;
            RbNovel.Checked = false;
            RbAmbos.Checked = false;
        }
    }
}