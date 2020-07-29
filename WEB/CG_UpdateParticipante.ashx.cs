using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB
{
    /// <summary>
    /// Descripción breve de CG_UpdateParticipante
    /// </summary>
    public class CG_UpdateParticipante : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "texto/normal";
            context.Response.Write("Hola a todos");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}