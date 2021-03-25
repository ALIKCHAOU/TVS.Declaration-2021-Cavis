using DevExpress.XtraEditors.DXErrorProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVS.Module.Virement.ImportsSql.Views
{
    public class LigneSqlView : IDXDataErrorInfo
    {
        public string Matricule { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string NomBanque { get; set; }

        public string CodeBanque { get; set; }

        public string CodeGuichet { get; set; }

        public string NumeroCompte { get; set; }

        public string CleRib { get; set; }

        public decimal NetAPaye { get; set; }

        public string Motif { get; set; }

        public void GetError(ErrorInfo info)
        {
          
        }

        public void GetPropertyError(string propertyName, ErrorInfo info)
        {
           
        }
    }
}
