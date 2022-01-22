using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace KEServiceV2.Services
{
    public static class CommonService
    {
        public static DateTime GetDateWithoutMilliseconds(DateTime d)
        {
            return new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
        }

        public static string FormatDateTime(string inputDate)
        {
            //2022-01-15 11:38:29.657000
            //return inputDate.ToString("yyyy'-'MM'-'dd hh':'mm':'ss'.'fff");

            //DateTime dtFormatedDate = DateTime.ParseExact(inputDate, "yyyy'-'MM'-'dd hh':'mm':'ss'.'fff", CultureInfo.InvariantCulture);

            return Convert.ToDateTime(inputDate).ToString("yyyy'-'MM'-'dd hh':'mm':'ss'.'ffffff");
                //dtFormatedDate.ToString();
        }

        public static void WriteErrorLog(Exception ex)
        {
            //string ErrorLogFolderPath = Application.CommonAppDataPath;
            string ErrorLogFolderPath = HttpContext.Current.Server.MapPath("~/Content/ErrorLog");
            //string ErrorLogFolderPath = Path.Combine(Directory.GetCurrentDirectory(), @"Content\ErrorLog");
            //string ErrorLogFolderPath = @"E:\Projects\BooksAppV2\BooksAppV2\Content\ErrorLog\";



            if (!Directory.Exists(ErrorLogFolderPath))
            {
                Directory.CreateDirectory(ErrorLogFolderPath);
            }

            string ErrorFileName = "ErrorLog_" + DateTime.Now.ToString("dd_MM_yyyy") + ".txt";

            string ErrorFilePath = Path.Combine(ErrorLogFolderPath, ErrorFileName);

            if (!File.Exists(ErrorFilePath))
            {
                using (FileStream fs = File.Create(ErrorFilePath))
                {

                }

                // write file
                WriteExceptioninInFile(ErrorFilePath, ex);
            }
            else
            {
                // write file
                WriteExceptioninInFile(ErrorFilePath, ex);
            }

        }

        private static void WriteExceptioninInFile(string FilePath, Exception ex)
        {
            using (StreamWriter writer = new StreamWriter(FilePath, true))
            {
                writer.WriteLine("-----------------------------------------------------------------------------");
                writer.WriteLine("Date : " + DateTime.Now.ToString());
                writer.WriteLine();

                while (ex != null)
                {
                    writer.WriteLine(ex.GetType().FullName);
                    writer.WriteLine("Message : " + ex.Message);
                    writer.WriteLine("StackTrace : " + ex.StackTrace);

                    ex = ex.InnerException;
                }
            }
        }
    }
}