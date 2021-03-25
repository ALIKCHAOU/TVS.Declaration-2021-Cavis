using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core.Enums;

namespace TVS.Core.Models
{
    public enum TypeMatriculCnss
    {
        [Description("Matricule")]
        Matricule = 0,
        [Description("Numéro Badge")]
        Badge = 1
    }
    public class Societe
    {
        public int Id { get; set; }
        public string RaisonSocial { get; set; }
        public string Activite { get; set; }
        public string Adresse { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }
        public string NumeroEmployeur { get; set; }
        public string CleEmployeur { get; set; }
        public string MatriculFiscal { get; set; }
        public string MatriculCle { get; set; }
        public string MatriculCodeTva { get; set; }
        public string MatriculCategorie { get; set; }
        public string MatriculEtablissement { get; set; }
        public string CodeBureau { get; set; }
        public int? CurrentExerciceNo { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public TypeAuthentification Type { get; set; }
        public TypeMatriculCnss CnssTypeMatricule{get;set;}
        public string GetConnection()
        {
            var typeCnx = Type == TypeAuthentification.Sql
                ? "User id=" + User + ";Password=" + Password + ";"
                : "Integrated Security=SSPI;";

            return "Data Source=" + ServerName + ";Initial Catalog=" + DatabaseName + ";" + typeCnx;
        }
    }
}