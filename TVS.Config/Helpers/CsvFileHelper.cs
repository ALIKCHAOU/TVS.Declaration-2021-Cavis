using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace TVS.Config.Helpers
{
    public static class CsvFileHelper
    {
        public static void ReplaceInFile(string filePath)
        {
            try
            {
                string content;
                using (var reader = new StreamReader(filePath, Encoding.GetEncoding(1252)))
                {
                    content = reader.ReadToEnd();
                    reader.Close();
                }

                content = Regex.Replace(content, "\"", "");
                content = Regex.Replace(content, "=", "");
                using (var writer = new StreamWriter(filePath, false, Encoding.GetEncoding(1252)))
                {
                    writer.Write(content);
                    writer.Close();
                }

            }
            catch (Exception)
            {
            }
        }
    }
}