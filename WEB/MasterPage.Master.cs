using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTR;

namespace WEB
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        Log log = new Log();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    log.CustomWriteOnLog("Master", "-------------------------------------------------------------------------------------------------------------");
                    log.CustomWriteOnLog("Master", "-----------------------------Ingresando a masterpage y Obtener pestañas disponibles--------------------------");
                    log.CustomWriteOnLog("Master", "-------------------------------------------------------------------------------------------------------------");
                    int perfil = int.Parse(Session["id_perfil"].ToString());
                    lblNombre.Text = Session["NombreUsuario"].ToString() + " " + Session["ApellidoP"].ToString() + " " + Session["ApellidoM"].ToString();


                    switch (perfil)
                    {
                        case 3://gerente
                            perfil_Usuario_Gerente();
                            break;
                        case 4://recepcionista
                            perfil_Recepcionista();
                            break;
                        case 5://jurado
                            perfil_Jurado();
                            break;
                        case 6://Profesor
                            perfil_Profesor();
                            break;
                        case 7://gestor
                            perfil_Gestor();
                            break;
                        case 8://gestor
                            perfil_Presentador();
                            break;
                        default:
                            Session.Clear();
                            Session.Abandon();
                            HttpContext.Current.Session.Abandon();
                            Session.RemoveAll();
                            Response.Redirect("~/Login_.aspx");
                            break;
                    }
                    //Session.Clear();
                }
            }
            catch (Exception ex)
            {
                log.CustomWriteOnLog("Master", "Error : " + ex.Message + "Stac" + ex.StackTrace);
            }
        }
        public void perfil_Usuario_Gerente()
        {

            log.CustomWriteOnLog("Master", " Session['NombreUsuario'] " + Session["NombreUsuario"]);
            string dni = Session["DNIUsuario"].ToString();

            string html = string.Format(@"
                         
                <ul class='nav'>
                    <li class='active'>
                        <a href = 'MASTER_EXTERNO/index_Externo.html'>
                            <i class='material-icons'>dashboard</i>
                            <p>Inicio</p>
                        </a>
                    </li>
                    
                    <li>
                        <a data-toggle='collapse' href='#gestionConcurso'>
                            <i class='material-icons'>emoji_events</i>
                            <p>
                                Gestion Concurso

                                <b class='caret'></b>
                            </p>
                        </a>
                        <div class='collapse' id='gestionConcurso'>
                            <ul class='nav'>
                                <li>
                                    <a href = 'W_GestionarConcurso.aspx' > Gestionar Concurso</a>
                                </li>
                                <li>
                                    <a href = 'W_Inscribir_ParticipanteP.aspx' > Inscribir Participante</a>
                                </li>
                                <li>
                                    <a href = '#' > Adminitrar Participante</a>
                                </li>
                            </ul>
                        </div>
                    </li>
                    <li>
                        <a data-toggle='collapse' href='#administrarAlumnos'>
                            <i class='material-icons'>school</i>
                            <p>
                                Administrar Alumno

                                <b class='caret'></b>
                            </p>
                        </a>
                        <div class='collapse' id='administrarAlumnos'>
                            <ul class='nav'>
                                
                                <li>
                                    <a href = 'W_RegistrarAlumno2.aspx' > Registrar Alumno</a>
                                </li>
                                <li>
                                    <a href = 'W_Registrar_Pago.aspx' > Registrar Pago</a>
                                </li>
                                <li>
                                    <a href = '#' > Listar Alumno</a>
                                </li>
                            </ul>
                        </div>
                    </li>
                </ul>
                    ");
            string img = String.Format(@"<img src='../assets/img/faces/avatar.jpg'/>");
            this.Literal2.Text = img;
            this.Literal1.Text = html;
        }
        public void perfil_Recepcionista()
        {
            string html = string.Format(@"
                         
                <ul class='nav'>
                    <li class='active'>
                        <a href = 'MASTER_EXTERNO/index_Externo.html'>
                            <i class='material-icons'>dashboard</i>
                            <p>Inicio</p>
                        </a>
                    </li>
                    <li>
                        <a data-toggle='collapse' href='#administrarAlumnos'>
                            <i class='material-icons'>school</i>
                            <p>
                                Administrar Alumno

                                <b class='caret'></b>
                            </p>
                        </a>
                        <div class='collapse' id='administrarAlumnos'>
                            <ul class='nav'>
                                
                                <li>
                                    <a href = 'W_RegistrarAlumno2.aspx' > Registrar Alumno</a>
                                </li>
                                <li>
                                    <a href = 'W_Registrar_Pago.aspx' > Registrar Pago</a>
                                </li>
                                <li>
                                    <a href = 'W_Listado_Alumnos_General.aspx'> Listado Alumnos</a>
                                </li>
                            </ul>
                        </div>
                    </li>    
               </ul> ");
            string img = String.Format(@"<img src='../assets/img/default-avatar.png'/>");
            this.Literal2.Text = img;
            this.Literal1.Text = html;
        }
        public void perfil_Gestor()
        {
            string html = string.Format(@"
                         
                <ul class='nav'>
                    <li class='active'>
                        <a href = 'MASTER_EXTERNO/index_Externo.html'>
                            <i class='material-icons'>dashboard</i>
                            <p>Inicio</p>
                        </a>
                    </li>
                    <li>
                        <a data-toggle='collapse' href='#gestionConcurso'>
                            <i class='material-icons'>emoji_events</i>
                            <p>
                                Gestion Concurso

                                <b class='caret'></b>
                            </p>
                        </a>
                        <div class='collapse' id='gestionConcurso'>
                            <ul class='nav'>
                                <li>
                                    <a href = 'W_Inscribir_ParticipanteP.aspx'> Inscribir Participante</a>
                                </li>
                                <li>
                                    <a href = '#' > Adminitrar Participante</a>
                                </li>
                                <li>
                                    <a href = 'W_Gestionar_Tanda.aspx' > Gestionar Tandas</a>
                                </li>
                            </ul>
                        </div>
                    </li>
               </ul> ");
            string img = String.Format(@"<img src='../assets/img/default-avatar.png'/>");
            this.Literal2.Text = img;
            this.Literal1.Text = html;
        }
        public void perfil_Profesor()
        {
            string html = string.Format(@"
                         
                <ul class='nav'>
                    <li class='active'>
                        <a href = 'MASTER_EXTERNO/index_Externo.html'>
                            <i class='material-icons'>dashboard</i>
                            <p>Inicio</p>
                        </a>
                    </li>
                    <li>
                        <a data-toggle='collapse' href='#administrarAlumnos'>
                            <i class='material-icons'>school</i>
                            <p>
                                Administrar Alumno

                                <b class='caret'></b>
                            </p>
                        </a>
                        <div class='collapse' id='administrarAlumnos'>
                            <ul class='nav'>
                                <li>
                                    <a href = 'W_Listar_Alumnos.aspx' > Listar Alumno</a>
                                </li>
                                <li>
                                    <a href = 'W_Listar_Asistencias.aspx' > Listar Asistencias</a>
                                </li>
                                <li>
                                    <a href = 'W_Listar_Progresos.aspx' > Listar Progresos</a>
                                </li>
                            </ul>
                        </div>
                    </li>    
               </ul> ");
            string img = String.Format(@"<img src='../assets/img/default-avatar.png'/>");
            this.Literal2.Text = img;
            this.Literal1.Text = html;
        }
        public void perfil_Jurado()
        {
            string html = string.Format(@"
                         
                <ul class='nav'>
                    <li class='active'>
                        <a href = 'MASTER_EXTERNO/index_Externo.html'>
                            <i class='material-icons'>dashboard</i>
                            <p>Inicio</p>
                        </a>
                    </li>
                    <li>
                        <a data-toggle='collapse' href='#gestionConcurso'>
                            <i class='material-icons'>emoji_events</i>
                            <p>
                                Gestion Concurso

                                <b class='caret'></b>
                            </p>
                        </a>
                        <div class='collapse' id='gestionConcurso'>
                            <ul class='nav'>
                                <li>
                                    <a href = 'W_Calificar_Participante.aspx' > Calificar Participante</a>
                                </li>
                                
                            </ul>
                        </div>
                    </li> 
               </ul> ");
            string img = String.Format(@"<img src='../assets/img/default-avatar.png'/>");
            this.Literal2.Text = img;
            this.Literal1.Text = html;
        }
        public void perfil_Presentador()
        {
            string html = string.Format(@"
                         
                <ul class='nav'>
                    <li class='active'>
                        <a href = 'MASTER_EXTERNO/index_Externo.html'>
                            <i class='material-icons'>dashboard</i>
                            <p>Inicio</p>
                        </a>
                    </li>
                    <li>
                        <a data-toggle='collapse' href='#gestionConcurso'>
                            <i class='material-icons'>emoji_events</i>
                            <p>
                                Gestion Concurso

                                <b class='caret'></b>
                            </p>
                        </a>
                        <div class='collapse' id='gestionConcurso'>
                            <ul class='nav'>
                                <li>
                                    <a href = 'W_Mostrar_Resultado.aspx' > Mostrar Resultado</a>
                                </li>
                           </ul>
                        </div>
                    </li>
               </ul> ");
            string img = String.Format(@"<img src='../assets/img/flags/trofeo.png'/>");
            this.Literal2.Text = img;
            this.Literal1.Text = html;
        }
    }
}