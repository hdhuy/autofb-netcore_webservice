using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace api.phanmemhay.info_version2.Extensions
{
    public static class LogExt
    {
        public static void WriteLog(string strLog)
        {
            StreamWriter log;
            FileStream fileStream = null;
            DirectoryInfo logDirInfo = null;
            FileInfo logFileInfo;

            string logFilePath = Directory.GetCurrentDirectory() + @"\" + "Log\\";
            string currTimeFileName = DateTime.Now.ToString("dd-MM-yyyy");
            logFilePath = logFilePath + "Log-" + currTimeFileName + "." + "txt";
            logFileInfo = new FileInfo(logFilePath);
            logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
            }
            else
            {
                fileStream = new FileStream(logFilePath, FileMode.Append);
            }
            log = new StreamWriter(fileStream);
            string currTimeStr = DateTime.Now.ToString("[dd-MM-yyyy HH:mm:ss]");
            strLog = currTimeStr + " " + strLog;
            log.WriteLine(strLog);
            log.Close();
        }
    }
}
