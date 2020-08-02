using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEB
{
    public partial class prueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txt_a.Attributes.Add("OnBlur", "sumar()");
            txt_b.Attributes.Add("OnBlur", "sumar()");
        }


        public static string BuscarNumAleatorio()    // el método debe ser de static
        {
            Random aleatorio = new Random();
            return aleatorio.Next(0, 1000).ToString();
        }

    }
}