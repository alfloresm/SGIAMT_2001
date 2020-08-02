using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTO;
using CTR;

namespace WEB
{
    public partial class W_Administrar_Asistencia_Alumno : System.Web.UI.Page
    {
        CtrAlumno objctrAlumno = new CtrAlumno();
        DtoUsuario objdtoalumno = new DtoUsuario();
        DtoAsistencia objdtoAsis = new DtoAsistencia();
        CtrNivel_TipoNivel objCtrNivelTipoNivel = new CtrNivel_TipoNivel();
        DtoNivel_TipoNivel objDtoNivelTipoNivel = new DtoNivel_TipoNivel();
        CtrAsistencia objctrasis = new CtrAsistencia();
        Log _log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            GVAlumnos.DataSource = objctrAlumno.ListaAlumnos_();
            GVAlumnos.DataBind();
            if (!IsPostBack)
            {
                _log.CustomWriteOnLog("administrar asistencia", "cargo: ");
                llenarClases();
                Label1.Text = DateTime.Today.Date.ToString("dd-MM-yyyy");
            }
        }

        public void llenarClases()
        {
            DataSet ds = new DataSet();
            ds = objCtrNivelTipoNivel.desplegableClase();
            ddlClase.DataSource = ds;
            ddlClase.DataTextField = "FK_ITN_CodTipoNivel";
            ddlClase.DataValueField = "FK_ITN_CodTipoNivel";
            ddlClase.DataBind();
            ddlClase.Items.Insert(0, new ListItem("Seleccione", "0"));
        }
        protected void GVAlumnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVAlumnos.DataSource = objctrAlumno.ListaAlumnos_();
            GVAlumnos.DataBind();
        }

         protected void btnBuscar1_Click1(object sender, EventArgs e)
        {
            _log.CustomWriteOnLog("administrar asistencia", "1");
            DtoNivel_TipoNivel dtoNiivelTipoNivel = new DtoNivel_TipoNivel();
            dtoNiivelTipoNivel.FK_ITN_CodTipoNivel = Convert.ToInt32(ddlClase.SelectedValue);
            dtoNiivelTipoNivel.FK_IN_CodNivel = Convert.ToInt32(ddlClase.SelectedValue);

            _log.CustomWriteOnLog("administrar asistencia", Convert.ToInt32(ddlClase.SelectedValue).ToString());

        }

        protected void GVAlumnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Detalle")
            {
                try
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    var colsNoVisible = GVAlumnos.DataKeys[index].Values;
                    string id = colsNoVisible[0].ToString();
                    objdtoalumno.PK_IU_DNI = int.Parse(id).ToString();
                    objctrasis.ObtenerDatosAlumno(objdtoalumno);
                    
                    
                    //txtDni.Text = objdtoalumno.PK_IU_DNI;
                    //txtNombre.Text = objdtoalumno.VU_Nombre;
                    //txtApellidoP.Text = objdtoalumno.VU_APaterno;
                    //txtApellidoM.Text = objdtoalumno.VU_AMaterno;
                    //txtTipoNivel.Text = objdtoalumno.FK_ITN_TipoNivel.ToString();
                    //txtNivel.Text = objdtoalumno.FK_IN_CodNivel.ToString();
                    //txtHorario.Text = objdtoalumno.VU_Horario;

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#noticeModal').modal('show');</script>", false);
                }
                catch (Exception ex)
                {
                    _log.CustomWriteOnLog("listar alumnos", ex.Message);
                }
            }
            else if (e.CommandName == "Asistencia")
            {
               
                int index = Convert.ToInt32(e.CommandArgument);
                var colsNoVisible = GVAlumnos.DataKeys[index].Values;
                string id = colsNoVisible[0].ToString();
                txtDni.Text = id;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#noticeModal').modal('show');</script>", false);

            }
            else if (e.CommandName == "Progreso")
            {
                Response.Redirect("~/W_Gestionar_Progreso.aspx");
            }
        }

        protected void btnGuardar_Click1(object sender, EventArgs e)
        {

            _log.CustomWriteOnLog("registrar asistencia", "1");

            //if (rbAsiste.Checked)
            //{
            //    objdtoAsis.VA_EstadoAsistencia = "Asistió";

            //}

            //else

            //{
            //    objdtoAsis.VA_EstadoAsistencia = "Faltó";
            //}
           
            string b= this.Request.Form["tipopersona"];
            _log.CustomWriteOnLog("registrar asistencia", "es:"+b);
            objdtoAsis.fecha = DateTime.Now;
            objdtoAsis.FK_VU_Dni = txtDni.Text;
            objctrasis.RegistrarAsistencia(objdtoAsis);
            string m = "Se registró correctamente";

            Utils.AddScriptClientUpdatePanel(upBotonEnviar2, "showMessage('top','center','" + m + "','success')");
            //_log.CustomWriteOnLog("registrar asistencia", "registro: ");
            //UpdatePanel1.Update();
        }

        protected void btnGuardarAsis_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/W_Listar_Alumnos.aspx");
        }
    }
}