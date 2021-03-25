using System;

namespace TVS.Module.BcSuspenssion.UiBc.Views
{
    public class DeclarationView
    {
        public int Id { get; set; }

        public int ExerciceId { get; set; }

        public bool IsCloture { get; set; }

        public bool IsArchive { get; set; }

        public int Trimestre { get; set; }

        public DateTime Date { get; set; }

        public string Societe { get; set; }

        public string Annee { get; set; }
        public string NumeroAutorisation { get; set; }
    }
}