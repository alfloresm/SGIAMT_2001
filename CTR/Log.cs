using System;
using System.Globalization;
using System.IO;
using System.Text;


namespace CTR
{
    public class Log
    {
        bool EnableLog = true;

        private static void PrepareLog(string strPath)
        {
            if (!File.Exists(strPath))
            {
                using (File.CreateText(strPath))
                {

                }
            }
        }

        public void WriteOnLog(string strMessage)
        {
            if (EnableLog)
            {
                string strPath = AppDomain.CurrentDomain.BaseDirectory + @"\Log.txt";
                string strDate = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture); // 12 horas

                PrepareLog(strPath);

                using (StreamWriter sw = new StreamWriter(strPath, true, Encoding.Unicode))
                {
                    sw.WriteLine(strDate + " : " + strMessage);
                }
            }
        }

        public void CustomWriteOnLog(string strFileName, string strMessage)
        {
            if (EnableLog)
            {
                string strPath = AppDomain.CurrentDomain.BaseDirectory + @"\Log\" + strFileName + ".txt";
                string strDate = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss.fff tt", CultureInfo.InvariantCulture); // 12 horas

                PrepareLog(strPath);

                using (StreamWriter sw = new StreamWriter(strPath, true, Encoding.Unicode))
                {
                    sw.WriteLine(strDate + " : " + strMessage);
                }
            }
        }

        public void DeleteLog()
        {
            string strPath = AppDomain.CurrentDomain.BaseDirectory + @"\Log.txt";
            File.Delete(strPath);
        }

        public void DeleteCustomLog(string strFileName)
        {
            string strPath = AppDomain.CurrentDomain.BaseDirectory + @"\Log\" + strFileName + ".txt";
            File.Delete(strPath);
        }
    }
}
