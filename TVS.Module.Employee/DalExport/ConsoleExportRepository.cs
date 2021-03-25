using System;
using System.IO;
using System.Text;

namespace Tvs.Module.Employee.DalExport
{
    public class ConsoleExportRepository : IExportRepostiory
    {
        public void Write(string enregistrementText)
        {
            Console.WriteLine(enregistrementText);
        }

        public void Write(string enregistrementText, string nameFile, string directory)
        {
            throw new NotImplementedException();
        }
    }

    public class FileExportRepository : IExportRepostiory
    {
        private readonly string _path;

        public FileExportRepository(string path)
        {
            _path = path;
        }

        public void Write(string enregistrementText)
        {
            throw new NotImplementedException();
        }

        public void Write(string enregistrementText, string nameFile, string path)
        {
            path += @"\" + nameFile;

            using (var sw = new StreamWriter(new FileStream(path, FileMode.Create), Encoding.ASCII))
            {
                sw.WriteLine(enregistrementText);
            }
        }
    }
}