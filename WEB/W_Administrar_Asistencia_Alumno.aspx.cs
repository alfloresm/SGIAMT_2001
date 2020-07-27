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
        CtrNivel_TipoNivel objCtrNivelTipoNivel = new CtrNivel_TipoNivel();
        DtoNivel_TipoNivel objDtoNivelTipoNivel = new DtoNivel_TipoNivel();
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
            //if (e.CommandName == "Detalle")
            //{
            //    try
            //    {
            //        int index = Convert.ToInt32(e.CommandArgument);
            //        var colsNoVisible = GVAlumnos.DataKeys[index].Values;
            //        string id = colsNoVisible[0].ToString();
            //        objdtoalumno.PK_IU_DNI = id;
            //        objctrConcurso.ObtenerConcurso(objdtoconcurso);
            //        _log.CustomWriteOnLog("gestionar concurso", "dato concurso: " + objdtoalumno.VU_Nombre.ToString());
            //        _log.CustomWriteOnLog("gestionar concurso", "dato concurso: " + objdtoalumno.VU_APaterno.ToString());
            //        _log.CustomWriteOnLog("gestionar concurso", "dato concurso: " + objdtoalumno.VU_AMaterno.ToString());
            //        //.Text = objdtoconcurso.PK_IC_IdConcurso.ToString();
            //        myModalLabel.InnerText = objdtoconcurso.VC_NombreCon.ToString();
            //        txtlugar.Text = objdtoconcurso.VC_LugarCon.ToString();
            //        txtFecha.Text = objdtoconcurso.DTC_FechaConcurso.ToString("dd-MM-yyyy");
            //        txtCantSer.Text = "S/." + objdtoconcurso.DC_PrecioSeriado.ToString();
            //        txtCantNov.Text = "S/." + objdtoconcurso.DC_PrecioNovel.ToString();
            //        int est = Convert.ToInt32(objdtoconcurso.FK_IEC_IdEstado);
                    
            //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "none", "<script>$('#noticeModal').modal('show');</script>", false);
            //    }
            //    catch (Exception ex)
            //    {
            //        _log.CustomWriteOnLog("gestionar concurso", ex.Message);
            //    }
            //}
        }
    }
}