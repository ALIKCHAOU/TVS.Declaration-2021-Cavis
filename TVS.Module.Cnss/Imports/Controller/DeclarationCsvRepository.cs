using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CsvHelper;
using CsvHelper.Configuration;
using TVS.Config.Helpers;
using TVS.Module.Cnss.Imports.Views;

namespace TVS.Module.Cnss.Imports.Controller
{
    public interface IDeclarationCnssImportRepository
    {
        IEnumerable<LigneImportView> GetAll(string source);
    }

    public class ReglementClientCsvRepository : IDeclarationCnssImportRepository
    {
        public IEnumerable<LigneImportView> GetAll(string source)
        {
            if (string.IsNullOrEmpty(source))
                throw new ArgumentNullException("source");

            if (!File.Exists(source))
                throw new ApplicationException("Fichier Csv invalide!");

            CsvFileHelper.ReplaceInFile(source);
            using (var reader = new StreamReader(source, Encoding.GetEncoding(1252)))
            {
                using (var csv = new CsvReader(reader))
                {
                    CsvConfiguration config = csv.Configuration;
                    config.WillThrowOnMissingField = true;
                    // header record should be supplied
                    config.HasHeaderRecord = true;
                    // allow comments
                    config.AllowComments = true;
                    // character used to denote a line is commented out
                    config.Comment = '#';
                    // set csv reader Encoding
                    config.Encoding = Encoding.GetEncoding(1252);
                    // character used to separate the fields in a Csv row
                    config.Delimiter = ";";
                    config.QuoteAllFields = true;
                    config.IgnoreQuotes = true;
                    config.Quote = '"';
                    config.QuoteNoFields = false;
                    // a flag to tells the reader to ignore white space in the headers when
                    // matching columns to the properties by name
                    config.IgnoreHeaderWhiteSpace = false;
                    // register mapping
                    config.RegisterClassMap<DeclarationCnssImportMap>();
                    config.ThrowOnBadData = true;
                    // skip empty row
                    config.SkipEmptyRecords = true;

                    // read csv file
                    List<LigneImportView> result = csv.GetRecords<LigneImportView>().ToList();

                    return result;
                }
            }
        }
    }
}