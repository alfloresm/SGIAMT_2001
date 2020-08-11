using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using CTR;
using DTO;

namespace WEB
{
    public partial class W_RegistrarAlumno2 : System.Web.UI.Page
    {
        CtrAlumno objctralumno = new CtrAlumno();
        CtrCategoria objctrcat = new CtrCategoria();
        DtoUsuario objDtoAlumno = new DtoUsuario();
        DtoNivel objDtoNivel = new DtoNivel();
        Log _log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["Id"] != null)
                {
                    _log.CustomWriteOnLog("registrar alumno", "cargo: ");
                    llenarNivel();
                    txtPagina.InnerText = "Actualizar Alumno";
                    btnRegistrar.Text = "Actualizar";
                    obtenerAlumno2(Request.Params["Id"]);
                    //Panel1.Visible = true;
                    //Panel2.Visible = true;
                }

                else
                {
                    txtPagina.InnerText = "Registrar Concurso";
                    btnRegistrar.Text = "Registrar";
                    //Panel1.Visible = false;
                    //Panel2.Visible = false;
                }
            }
        }

        public void llenarNivel()
        {
            DataSet ds = new DataSet();
            ds = objctralumno.desplegableNivel();
            ddlNivel.DataSource = ds;
            ddlNivel.DataTextField = "VN_NombreNivel";
            ddlNivel.DataValueField = "PK_IN_CodNivel";
            ddlNivel.DataBind();
            ddlNivel.Items.Insert(0, new ListItem("Seleccione", "0"));
        }
        public void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDateTime(txtFechaNacimiento.Text) > DateTime.Now)
                {
                    string m = "Fecha de Nacimiento No Valida";
                    Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m + "','danger')");
                }
                else
                {
                    if (Request.Params["Id"] != null)
                    {
                        objDtoAlumno.PK_IU_DNI = txtDNI.Text;
                        objDtoAlumno.VU_Nombre = txtNombre.Text;
                        objDtoAlumno.VU_APaterno = txtApellidoP.Text;
                        objDtoAlumno.VU_AMaterno = txtApellidoM.Text;
                        objDtoAlumno.DTU_FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
                        objDtoAlumno.VU_Contrasenia = txtDNI.Text;
                        objDtoAlumno.VU_Sexo = Convert.ToString(ddlSexo.SelectedValue); //aparezca el dni ya fijo
                        objDtoAlumno.VU_NAcademia = "TUSUY PERU";
                        objDtoAlumno.VU_Correo = txtCorreo.Text;
                        objDtoAlumno.VU_Celular = txtCelular.Text;
                        objDtoAlumno.VU_Estado = "Activo";
                        objDtoAlumno.VU_Horario = Convert.ToString(ddlHorario.SelectedValue);
                        objDtoAlumno.VU_Direccion = txtDireccion.Text;
                        int anio = objDtoAlumno.DTU_FechaNacimiento.Year;
                        _log.CustomWriteOnLog("actualizar alumno", "dato alumno: " + objctralumno.devolverCategoria(anio));
                        objDtoAlumno.FK_ICA_CodCat = objctralumno.devolverCategoria(anio);
                        _log.CustomWriteOnLog("actualizar alumno", "dato alumno: " + objDtoAlumno.PK_IU_DNI.ToString());
                        objDtoAlumno.FK_IN_CodNivel = Convert.ToInt32(ddlNivel.SelectedValue);

                        if (anio >= 2012 && anio <= 2016)
                        {
                            objDtoAlumno.FK_ITN_TipoNivel = 1;
                        }
                        else
                            if (anio >= 2008 && anio <= 2013)
                        {
                            objDtoAlumno.FK_ITN_TipoNivel = 2;
                        }
                        else
                            if (anio <= 2007)
                        {
                            objDtoAlumno.FK_ITN_TipoNivel = 3;
                        }

                        objctralumno.ActualizarAlumno(objDtoAlumno);
                        string m = "Se actualizó correctamente";
                    }
                    else
                    {
                        _log.CustomWriteOnLog("registrar alumno", "1");
                        objDtoAlumno.PK_IU_DNI = txtDNI.Text;
                        objDtoAlumno.VU_Nombre = txtNombre.Text;
                        objDtoAlumno.VU_APaterno = txtApellidoP.Text;
                        objDtoAlumno.VU_AMaterno = txtApellidoM.Text;
                        objDtoAlumno.DTU_FechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
                        objDtoAlumno.VU_Contrasenia = txtDNI.Text;
                        objDtoAlumno.VU_Sexo = Convert.ToString(ddlSexo.SelectedValue); //aparezca el dni ya fijo
                        objDtoAlumno.VU_NAcademia = "TUSUY PERU";
                        objDtoAlumno.VU_Correo = txtCorreo.Text;
                        objDtoAlumno.VU_Celular = txtCelular.Text;
                        objDtoAlumno.VU_Estado = "Activo";
                        objDtoAlumno.VU_Horario = Convert.ToString(ddlHorario.SelectedValue);
                        objDtoAlumno.VU_Direccion = txtDireccion.Text;
                        int anio = objDtoAlumno.DTU_FechaNacimiento.Year;
                        _log.CustomWriteOnLog("registrar alumno", "dato alumno: " + objctralumno.devolverCategoria(anio));
                        objDtoAlumno.FK_ICA_CodCat = objctralumno.devolverCategoria(anio);
                        _log.CustomWriteOnLog("registrar alumno", "dato alumno: " + objDtoAlumno.PK_IU_DNI.ToString());
                        objDtoAlumno.FK_IN_CodNivel = Convert.ToInt32(ddlNivel.SelectedValue);

                        if (anio >= 2012 && anio <= 2016)
                        {
                            objDtoAlumno.FK_ITN_TipoNivel = 1;
                        }
                        else
                            if (anio >= 2008 && anio <= 2013)
                        {
                            objDtoAlumno.FK_ITN_TipoNivel = 2;
                        }
                        else
                            if (anio <= 2007)
                        {
                            objDtoAlumno.FK_ITN_TipoNivel = 3;
                        }

                        objctralumno.RegistrarAlumno(objDtoAlumno);
                        string m = "Se registró correctamente";

                        Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + m + "','success')");

                    }
                }
            }
            catch (Exception ex)
            {
                Utils.AddScriptClientUpdatePanel(upBotonEnviar, "showMessage('top','center','" + ex.Message + "','danger')");
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/W_Listado_Alumnos_General.aspx");
        }

        public void obtenerAlumno2(string cod)
        {
            //cambiar estos cambios
            objDtoAlumno.PK_IU_DNI = cod;
            objctralumno.ObtenerAlumno2(objDtoAlumno);

            txtDNI.Text = objDtoAlumno.PK_IU_DNI.ToString();
            txtNombre.Text = objDtoAlumno.VU_Nombre.ToString();
            txtApellidoP.Text = objDtoAlumno.VU_APaterno.ToString();
            txtApellidoM.Text = objDtoAlumno.VU_AMaterno.ToString();
            txtFechaNacimiento.Text = objDtoAlumno.DTU_FechaNacimiento.ToString("yyyy-MM-dd");
            txtContrasenia.Text = objDtoAlumno.VU_Contrasenia.ToString();
            ddlSexo.SelectedValue = objDtoAlumno.VU_Sexo;
            //nombre de academia
            txtCorreo.Text = txtCorreo.ToString();
            txtCelular.Text = objDtoAlumno.VU_Celular.ToString();
            //estado
            ddlHorario.SelectedValue = objDtoAlumno.VU_Horario.ToString();
            txtDireccion.Text = objDtoAlumno.VU_Direccion.ToString();
            //categoria
            //tipo de nivel
            ddlNivel.SelectedIndex = objDtoAlumno.FK_IN_CodNivel;
        }
    }
}