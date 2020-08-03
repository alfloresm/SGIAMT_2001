<%@ WebHandler Language="C#" Class="ghUploadFile" %>

using System;
using System.Web;
using System.IO;

using DTO;
using CTR;

public class ghUploadFile : IHttpHandler
{

    Log _Log = new Log();
    public void ProcessRequest(HttpContext context)
    {
        _Log.CustomWriteOnLog("Registrar Participante", "Entro a metodo ashx");
            try
            {
                if (context.Request.Files.Count > 0)
                {
                    CtrParticipante objCtrP = new CtrParticipante();
                    _Log.CustomWriteOnLog("Registrar Participante", "1");
                    string ID = context.Request.QueryString["Id"].ToString();
                    byte[] fileData = null;
                    _Log.CustomWriteOnLog("Registrar Participante", " 2");
                    using (var binaryReader = new BinaryReader(context.Request.Files[0].InputStream))
                    {
                        fileData = binaryReader.ReadBytes(context.Request.Files[0].ContentLength);
                    }
                    _Log.CustomWriteOnLog("Registrar Participant", "3");
                    _Log.CustomWriteOnLog("Registrar Participant", "Valor de Id a actualizar es" + ID);

                    objCtrP.registrarImgP(fileData, ID);
                    _Log.CustomWriteOnLog("Registrar Participant", "4");
                }
                _Log.CustomWriteOnLog("Registrar Participant", "5");
            }
            catch (Exception ex)
            {

                _Log.CustomWriteOnLog("Registrar Participante", "Error : " + ex.Message + "Stac" + ex.StackTrace);
            }

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}