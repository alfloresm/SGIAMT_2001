using System.Web;
using System.Text;
using System;
using System.Globalization;
using System.Web.UI;
using System.Transactions;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;

namespace CTR
{
    public static class Utils
    {
        public static string generarRandom()
        {
            DateTime dtFechaHoy = DateTime.Now;
            return dtFechaHoy.Hour.ToString("00") + dtFechaHoy.Minute.ToString("00") + dtFechaHoy.Second.ToString("00");
        }

        public static string removerCaracteresRestringidosPorSharePoint(string palabra)
        {

            char[] aStr = palabra.ToCharArray();
            StringBuilder sb = new StringBuilder(palabra.Length);
            for (int i = 0; i < aStr.Length; i++)
            {
                char c = aStr[i];
                if (Char.IsLetter(c) | Char.IsNumber(c) | Char.IsWhiteSpace(c))
                {
                    char[] nuevo = sb.ToString().ToCharArray();
                    int numero = nuevo.Length;
                    if (numero > 0 && i > 0)
                    {
                        char charAnterior = nuevo[numero - 1];
                        if (charAnterior == 32)
                            c = Char.ToUpperInvariant(c);
                        if (c == 32 && c == charAnterior)
                            continue;
                    }
                    sb.Append(c);
                }
            }

            string strCadenaConEspaciosEnBlanco = sb.ToString();
            return strCadenaConEspaciosEnBlanco.Trim().Replace(" ", "_");
        }

        public static string removerCaracteresDeAutores(string palabra)
        {
            char[] aStr = palabra.ToCharArray();
            StringBuilder sb = new StringBuilder(palabra.Length);
            for (int i = 0; i < aStr.Length; i++)
            {
                char c = aStr[i];
                if (Char.IsLetter(c) | Char.IsWhiteSpace(c) | c == 44 | c == 59)
                {
                    char[] nuevo = sb.ToString().ToCharArray();
                    int numero = nuevo.Length;
                    if (numero > 0 && i > 0)
                    {
                        char charAnterior = nuevo[numero - 1];
                        if (c == 59 && c == charAnterior)//evita doble seguido ;;
                            continue;
                    }
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Gets the MIME type of the file name specified based on the file name's
        /// extension.  If the file's extension is unknown, returns "octet-stream"
        /// generic for streaming file bytes.
        /// </summary>
        /// <param name="sFileName">The name of the file for which the MIME type
        /// refers to.</param>
        public static string GetMimeTypeByFileName(string sFileName)
        {
            string sMime = "application/octet-stream";

            string sExtension = System.IO.Path.GetExtension(sFileName);
            if (!string.IsNullOrEmpty(sExtension))
            {
                sExtension = sExtension.Replace(".", "");
                sExtension = sExtension.ToLower();

                if (sExtension == "xls" || sExtension == "xlsx")
                {
                    sMime = "application/ms-excel";
                }
                else if (sExtension == "doc" || sExtension == "docx")
                {
                    sMime = "application/msword";
                }
                else if (sExtension == "ppt" || sExtension == "pptx")
                {
                    sMime = "application/ms-powerpoint";
                }
                else if (sExtension == "rtf")
                {
                    sMime = "application/rtf";
                }
                else if (sExtension == "zip")
                {
                    sMime = "application/zip";
                }
                else if (sExtension == "mp3")
                {
                    sMime = "audio/mpeg";
                }
                else if (sExtension == "bmp")
                {
                    sMime = "image/bmp";
                }
                else if (sExtension == "gif")
                {
                    sMime = "image/gif";
                }
                else if (sExtension == "jpg" || sExtension == "jpeg")
                {
                    sMime = "image/jpeg";
                }
                else if (sExtension == "png")
                {
                    sMime = "image/png";
                }
                else if (sExtension == "tiff" || sExtension == "tif")
                {
                    sMime = "image/tiff";
                }
                else if (sExtension == "txt")
                {
                    sMime = "text/plain";
                }
            }

            return sMime;
        }

        /// <summary>
        /// Formato 23:59
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static bool horaValida(string valor)
        {//^([0]?[1-9]|[2][0-3]):([0-5][0-9]|[1-9])$
            Regex regexp = new System.Text.RegularExpressions.Regex("^([0-1]?[0-9]|[2][0-3]):([0-5][0-9]|[1-9])$");
            return regexp.IsMatch(valor);
        }

        ///<summary>
        /// Base 64 Encoding with URL and Filename Safe Alphabet using UTF-8 character set.
        ///</summary>
        ///<param name="str">The origianl string</param>
        ///<returns>The Base64 encoded string</returns>
        public static string Base64Encode(string str)
        {
            byte[] encbuff = Encoding.UTF8.GetBytes(str);
            return HttpServerUtility.UrlTokenEncode(encbuff);
        }

        ///<summary>
        /// Decode Base64 encoded string with URL and Filename Safe Alphabet using UTF-8.
        ///</summary>
        ///<param name="str">Base64 code</param>
        ///<returns>The decoded string.</returns>
        public static string Base64Decode(string str)
        {
            byte[] decbuff = HttpServerUtility.UrlTokenDecode(str);
            return Encoding.UTF8.GetString(decbuff);
        }

        public delegate bool ParseToDelegate<T>(string value, out T result);

        public delegate bool ParseToCultureDelegate<T>(string value,
            NumberStyles style, IFormatProvider provider, out T result);

        public static T? ParseTo<T>(this string value, ParseToDelegate<T> method) where T : struct
        {
            T result;
            if (String.IsNullOrEmpty(value)) return null;
            if (method(value, out result)) return result;
            return null;
        }

        /*start xml*/
        public static XElement ToXElement<T>(this object obj)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (TextWriter streamWriter = new StreamWriter(memoryStream))
                {
                    var xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(streamWriter, obj);
                    return XElement.Parse(Encoding.ASCII.GetString(memoryStream.ToArray()));
                }
            }
        }

        public static T FromXElement<T>(this XElement xElement)
        {
            using (var memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(xElement.ToString())))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                return (T)xmlSerializer.Deserialize(memoryStream);
            }
        }

        public static System.Xml.XmlDocument SerializeToXMLDocument<T>(this object obj)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            //TextWriter textWriter = new StreamWriter(@"C:\movie.xml");
            StringBuilder sb = new StringBuilder();
            System.Xml.XmlWriter xmlwriter = System.Xml.XmlWriter.Create(sb);
            serializer.Serialize(xmlwriter, obj);
            xmlwriter.Close();
            xmlwriter.Flush();

            System.Xml.XmlDocument xml = new System.Xml.XmlDocument();
            xml.LoadXml(sb.ToString());
            return xml;
        }
        /*end xml*/

        public static void SendErrorPage(string mensaje)
        {
            Page page = (Page)HttpContext.Current.CurrentHandler;
            if (string.IsNullOrEmpty(mensaje))
                page.Server.Transfer("error.aspx");
            else
                page.Server.Transfer("error.aspx?msg=" + mensaje);
        }

        public static TransactionScope transaccion()
        {
            TransactionOptions trans = new TransactionOptions();
            trans.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            TimeSpan tiempo = new TimeSpan(0, 1, 10);
            TransactionScope trx = new TransactionScope(TransactionScopeOption.Required, trans);
            return trx;
        }

        public static string GetJson(DataTable dt)
        {
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;

            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            return serializer.Serialize(rows);
        }

        public static string getJavaScriptTag(string script)
        {
            return string.Concat("<script type=\"text/javascript\">", script, "</script>");
        }

        #region AddScriptClient
        public static void AddScriptClient(string strScript)
        {
            Page page = (Page)HttpContext.Current.Handler;
            page.ClientScript.RegisterStartupScript(typeof(Page), Guid.NewGuid().ToString(), strScript, true);

        }

        public static void AddScriptClientUpdatePanel(UpdatePanel control, string script)
        {
            ScriptManager.RegisterStartupScript(control, control.GetType(), Guid.NewGuid().ToString(), script, true);
        }

        #endregion


        public static string obNombreMes(int intmes)
        {
            string strNombMes = "";
            switch (intmes)
            {
                case 1:
                    strNombMes = "Enero";
                    break;
                case 2:
                    strNombMes = "Febrero";
                    break;
                case 3:
                    strNombMes = "Marzo";
                    break;
                case 4:
                    strNombMes = "Abril";
                    break;
                case 5:
                    strNombMes = "Mayo";
                    break;
                case 6:
                    strNombMes = "Junio";
                    break;
                case 7:
                    strNombMes = "Julio";
                    break;
                case 8:
                    strNombMes = "Agosto";
                    break;
                case 9:
                    strNombMes = "Setiembre";
                    break;
                case 10:
                    strNombMes = "Octubre";
                    break;
                case 11:
                    strNombMes = "Noviembre";
                    break;
                case 12:
                    strNombMes = "Diciembre";
                    break;
            }
            return strNombMes;
        }

        public static string obNombreMesAbrv(int intmes)
        {
            string strNombMes = "";
            switch (intmes)
            {
                case 1:
                    strNombMes = "Ene";
                    break;
                case 2:
                    strNombMes = "Feb";
                    break;
                case 3:
                    strNombMes = "Mar";
                    break;
                case 4:
                    strNombMes = "Abr";
                    break;
                case 5:
                    strNombMes = "May";
                    break;
                case 6:
                    strNombMes = "Jun";
                    break;
                case 7:
                    strNombMes = "Jul";
                    break;
                case 8:
                    strNombMes = "Ago";
                    break;
                case 9:
                    strNombMes = "Set";
                    break;
                case 10:
                    strNombMes = "Oct";
                    break;
                case 11:
                    strNombMes = "Nov";
                    break;
                case 12:
                    strNombMes = "Dic";
                    break;
            }
            return strNombMes;
        }

        public static string RemoveAccents(string inputString)
        {
            Regex replace_a_Accents = new Regex("[á|à|ä|â]", RegexOptions.Compiled);
            Regex replace_e_Accents = new Regex("[é|è|ë|ê]", RegexOptions.Compiled);
            Regex replace_i_Accents = new Regex("[í|ì|ï|î]", RegexOptions.Compiled);
            Regex replace_o_Accents = new Regex("[ó|ò|ö|ô]", RegexOptions.Compiled);
            Regex replace_u_Accents = new Regex("[ú|ù|ü|û]", RegexOptions.Compiled);
            inputString = replace_a_Accents.Replace(inputString, "a");
            inputString = replace_e_Accents.Replace(inputString, "e");
            inputString = replace_i_Accents.Replace(inputString, "i");
            inputString = replace_o_Accents.Replace(inputString, "o");
            inputString = replace_u_Accents.Replace(inputString, "u");
            return inputString;
        }

        public static byte[] StrToByteArray(string str)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetBytes(str);
        }

        public static string byteToString(object objName)
        {
            string returnValue = "";

            byte[] ObjInput;
            try
            {
                ObjInput = (byte[])objName;
                returnValue = System.Text.ASCIIEncoding.ASCII.GetString(ObjInput);
            }
            catch (Exception ex)
            {
                returnValue = (string)objName;
            }

            return returnValue;
        }


        public static bool isEmailValid(string strEmail)
        {
            if (string.IsNullOrEmpty(strEmail))
                return false;

            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(strEmail.Trim()))
                return (true);
            else
                return (false);
        }


        public static string currencyFormat(string moneda, double monto)
        {
            return moneda + " " + string.Format("{0:#,0.00}", monto);     // US$123,000,000.00
        }

        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }
    }
}
