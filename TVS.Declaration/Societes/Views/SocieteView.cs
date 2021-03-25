using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVS.Core.Models;

namespace TVS.Declaration.Societes.Views
{
    public class SocieteView
    {
        public SocieteView()
        {
            ConnectionView = new ConnectionView();
        }

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

        public string MatriculCategorie { get; set; }
        public string MatriculCodeTva { get; set; }

        public string MatriculEtablissement { get; set; }

        public string CodeBureau { get; set; }

        public int? CurrentExerciceNo { get; set; }

        public ConnectionView ConnectionView { get; set; }
        public TypeMatriculCnss CnssTypeMatricule { get; set; }
    }
}