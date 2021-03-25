using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using Tvs.Module.Employee.Imports.Interfaces;
using Tvs.Module.Employee.Imports.Maps;
using TVS.Config.Helpers;
using TVS.Module.Employee.Imports.Views;

namespace TVS.Module.Employee.Imports.Repsitory
{
    public class LigneAnnexe6ImportRepository : ILigneAnnexeSixImportRepository
    {
        public IEnumerable<LigneAnnexe6ImportView> GetAll(string source)
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
                    var config = csv.Configuration;
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
                    config.RegisterClassMap<LigneAnnexeSixImportMap>();
                    config.ThrowOnBadData = true;
                    // skip empty row
                    config.SkipEmptyRecords = true;
                    // read csv file
                    var result = csv.GetRecords<LigneAnnexe6ImportView>().ToList();

                    return result;
                }
            }
        }
    }
}