namespace Tvs.Module.Employee.DalExport
{
    public interface IExportRepostiory
    {
        void Write(string enregistrementText);

        void Write(string enregistrementText, string nameFile, string directory);
    }
}