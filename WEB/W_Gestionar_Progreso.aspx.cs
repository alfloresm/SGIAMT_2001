using System;
using DTO;
using CTR;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WEB
{
    public partial class W_Gestionar_Progreso : System.Web.UI.Page
    {
        CtrProgreso objCtrprogreso = new CtrProgreso();
        DtoProgreso objDtoProgreso = new DtoProgreso();
        CtrAsistencia objctrAsistencia = new CtrAsistencia();
        DtoAsistencia objdtoAsistencia = new DtoAsistencia();

        Log _log = new Log();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Request.Params["Id"] != null)
                {

                    txtPagina.InnerText = "Actualizar Progreso";
                    btnRegistrar.Text = "Actualizar";
                    

                }
                else
                {
                    txtPagina.InnerText = "Registrar Progreso";
                    btnRegistrar.Text = "Registrar";
                    
                }
            }
        }
 

        [System.Web.Services.WebMethod]
        public static string registrar(string VP_NombreProgreso, double DP_NotaPasos, double DP_NotaTecnica, double DP_NotaInteres, double DP_NotaHabilidad, double DP_TotalNota, string VP_Observacion,string dni)
        {
            DtoProgreso objDtoProgreso = new DtoProgreso();
            CtrProgreso objCtrprogreso = new CtrProgreso();
            CtrAsistencia objctrasis = new CtrAsistencia();
            Log _log = new Log();
       
            
            String valor;
            try
            {
                _log.CustomWriteOnLog("listar alumnos", "el valor del dni es:" + dni);

                int codigopk = objctrasis.obtenerIdAsis(dni);
                _log.CustomWriteOnLog("listar alumnos", "el valor del codigopk es:" + codigopk);

                objDtoProgreso.VP_NombreProgreso = VP_NombreProgreso;
                objDtoProgreso.DP_NotaPasos = DP_NotaPasos;
                objDtoProgreso.DP_NotaTecnica = DP_NotaTecnica;
                objDtoProgreso.DP_NotaInteres = DP_NotaInteres;
                objDtoProgreso.DP_NotaHabilidad = DP_NotaHabilidad;
                objDtoProgreso.DP_TotalNota = DP_TotalNota;
                objDtoProgreso.VP_Observacion = VP_Observacion;
                objDtoProgreso.FK_IA_CodAsi = codigopk;
                objCtrprogreso.RegistrarProgresoAlumno(objDtoProgreso);
                valor = "Todo Bien, todo Correcto";

                //string m = "Se registró correctamente el progreso del alumno";
                //Utils.AddScriptClientUpdatePanel(upBotonEnviar2, "showMessage('top','center','" + m + "','success')");
            }
            catch (Exception e)
            {
                valor = "pasó:" + e.Message;
            }

            return valor;
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                objDtoProgreso.VP_NombreProgreso = txtNombreProgreso.Text;
                objDtoProgreso.DP_NotaPasos = Convert.ToDouble(txtNota1.Text);
                objDtoProgreso.DP_NotaTecnica = Convert.ToDouble(txtNota2.Text);
                objDtoProgreso.DP_NotaInteres = Convert.ToDouble(txtNota3.Text);
                objDtoProgreso.DP_NotaHabilidad = Convert.ToDouble(txtNota4.Text);
                //txtNotaTotal.Text = calcularNotas().ToString();

                objDtoProgreso.DP_TotalNota = Convert.ToDouble(txtNotaTotal.Text);
                _log.CustomWriteOnLog("registrar progreso", txtObservacion.Text);
                objDtoProgreso.VP_Observacion = txtObservacion.Text;
                _log.CustomWriteOnLog("registrar progreso", txtObservacion.Text);
                objDtoProgreso.FK_IA_CodAsi = objctrAsistencia.obtenerIdAsis(objdtoAsistencia.FK_VU_Dni); //me falta la fk de la asistencia
                _log.CustomWriteOnLog("registrar progreso", "dato progreso: " + objDtoProgreso.PK_IP_CodProgreso.ToString());
                objCtrprogreso.RegistrarProgresoAlumno(objDtoProgreso);
                string m = "Se registró correctamente el progreso del alumno";

                Utils.AddScriptClientUpdatePanel(upBotonEnviar2, "showMessage('top','center','" + m + "','success')");
            }

            catch (Exception ex)
            {
                _log.CustomWriteOnLog("registrar progreso", "Error : " + ex.Message + "Stac" + ex.StackTrace);
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/W_Listar_Alumnos.aspx");
        }

        //public double calcularNotas()
        //{
        //    double n1 = double.Parse(txtNota1.Text);
        //    double n2 = double.Parse(txtNota2.Text);
        //    double n3 = double.Parse(txtNota3.Text);
        //    double n4 = double.Parse(txtNota4.Text);
        //    double total = (n1 + n2 + n3 + n4) / 4;
        //    _log.CustomWriteOnLog("registrar progreso", "promedio:" + txtNotaTotal);
        //    txtNotaTotal.Text = total.ToString();
        //    _log.CustomWriteOnLog("registrar progreso", "porcentaje:" + txtProgresoP);
        //    txtProgresoP.Text = ((total * 100) / 20).ToString() + " %";
        //    return total;
        //}

    }
}