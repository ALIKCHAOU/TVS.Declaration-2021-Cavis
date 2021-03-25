using System;
using System.ComponentModel;

namespace TVS.Module.BcSuspenssion.Imports.Views
{
    public class DeclarationImportView
    {
        public int Id { get; set; }

        public int ExerciceId { get; set; }

        public string Exercice { get; set; }

        public int SocieteId { get; set; }

        public int Trimestre { get; set; }

        public DateTime Date { get; set; }

        public string RaisonSocial { get; set; }

        public string NumeroEmployeur { get; set; }

        public string NumeroAutorisation { get; set; }

        public string Path { get; set; }

        public int CategorieNo { get; set; }

        public BindingList<LigneBcSuspendueImportView> Lignes { get; set; }
    }
}