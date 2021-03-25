using System;
using System.ComponentModel;
using TVS.Module.Cnss.Imports.Views;

namespace TVS.Module.Cnss.ImportsSql.Views
{
    public class DeclarationImportSqlView
    {
        public int Id { get; set; }

        public int ExerciceId { get; set; }

        public string Exercice { get; set; }

        public int SocieteId { get; set; }

        public int Trimestre { get; set; }

        public bool Complementaire { get; set; }

        public DateTime Date { get; set; }

        public string RaisonSocial { get; set; }

        public string NumeroEmployeur { get; set; }
        public string Etablissement { get; set; }

        public int CategorieNo { get; set; }

        public BindingList<LigneSqlView> Lignes { get; set; }
    }
}